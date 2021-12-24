// Implementation mostly lifted from Flib's SkillUpgrades mod.
using System;
using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;
using UnityEngine;
using ItemChanger.FsmStateActions;
using ItemChanger.Extensions;
using ItemChanger.Util;

namespace ItemChanger.Modules
{
    /// <summary>
    /// Module which implements the vertical superdash custom skill.
    /// </summary>
    public class VerticalSuperdash : Module
    {
        public bool hasVerticalSuperdash { get; set; }

        private bool hasModifiedFsm = false;

        private const bool DiagonalSuperdash = true;
        private const bool ChangeDirectionInMidair = false;
        private bool SkillUpgradeActive => hasVerticalSuperdash;

        public override void Initialize()
        {
            On.CameraTarget.Update += FixVerticalCamera;
            On.GameManager.FinishedEnteringScene += DisableUpwardOneways;
            On.HeroController.Start += ModifySuperdashFsm;
            On.HeroAnimationController.canPlayTurn += FixCdashAnimation;
            Modding.ModHooks.GetPlayerBoolHook += SkillBoolGetOverride;
            Modding.ModHooks.SetPlayerBoolHook += SkillBoolSetOverride;
        }

        public override void Unload()
        {
            On.CameraTarget.Update -= FixVerticalCamera;
            On.GameManager.FinishedEnteringScene -= DisableUpwardOneways;
            // Can't undo the FSM edits, but they should not break
            // anything while this module isn't enabled.
            On.HeroAnimationController.canPlayTurn += FixCdashAnimation;
            Modding.ModHooks.GetPlayerBoolHook -= SkillBoolGetOverride;
            Modding.ModHooks.SetPlayerBoolHook -= SkillBoolSetOverride;
        }

        private bool SkillBoolGetOverride(string boolName, bool value)
        {
            return boolName switch
            {
                nameof(hasVerticalSuperdash) => hasVerticalSuperdash,
                _ => value
            };
        }

        private bool SkillBoolSetOverride(string boolName, bool value)
        {
            if (boolName == nameof(hasVerticalSuperdash))
            {
                hasVerticalSuperdash = value;
            }
            return value;
        }

        private bool FixCdashAnimation(On.HeroAnimationController.orig_canPlayTurn orig, HeroAnimationController self)
        {
            return !HeroController.instance.cState.superDashing && orig(self);
        }

        /// <summary>
        /// The angle the knight is superdashing, measured anticlockwise when the knight is facing left and clockwise when facing right
        /// </summary>
        internal float SuperdashAngle { get; set; } = 0f;

        private GameObject burst;
        internal void ResetSuperdashAngle()
        {
            if (!HeroController.instance.cState.superDashing && SuperdashAngle == 0f)
            {
                return;
            }

            SuperdashAngle = 0f;
            HeroRotation.ResetHero();

            if (burst != null)
            {
                burst.transform.parent = HeroController.instance.transform;
                burst.transform.rotation = Quaternion.identity;

                Vector3 vec = burst.transform.localScale;
                vec.x = Math.Abs(vec.x);
                burst.transform.localScale = vec;

                burst.SetActive(false);
            }
        }

        // This function is slightly broken :(
        private void FixVerticalCamera(On.CameraTarget.orig_Update orig, CameraTarget self)
        {
            orig(self);
            if (self.hero_ctrl == null || GameManager.instance == null || !GameManager.instance.IsGameplayScene()) return;
            if (!self.superDashing) return;

            self.cameraCtrl.lookOffset += Math.Abs(self.dashOffset) * Mathf.Sin(SuperdashAngle * Mathf.PI / 180);
            self.dashOffset *= Mathf.Cos(SuperdashAngle * Mathf.PI / 180);
        }
        // Deactivate upward oneway transitions after spawning in so the player doesn't accidentally
        // softlock by vc-ing into them
        private void DisableUpwardOneways(On.GameManager.orig_FinishedEnteringScene orig, GameManager self)
        {
            orig(self);

            switch (self.sceneName)
            {
                // The KP top transition is the only one that needs to be disabled; the others have collision
                case "Tutorial_01":
                    if (GameObject.Find("top1") is GameObject topTransition)
                        topTransition.SetActive(false);
                    break;
            }
        }

        private void ModifySuperdashFsm(On.HeroController.orig_Start orig, HeroController self)
        {
            orig(self);
            if (hasModifiedFsm)
            {
                return;
            }
            hasModifiedFsm = true;
            
            burst = self.transform.Find("Effects/SD Burst").gameObject;

            PlayMakerFSM fsm = self.superDash;

            #region Add FSM Variables
            FsmFloat vSpeed = fsm.AddFsmFloat("V Speed VC");
            FsmFloat hSpeed = fsm.AddFsmFloat("H Speed VC");
            #endregion

            #region Set Direction
            fsm.GetState("Direction").AddFirstAction(new Lambda(() =>
            {
                bool shouldDiagonal = false;
                bool shouldVertical = false;
                if (DiagonalSuperdash && SkillUpgradeActive)
                {
                    if (GameManager.instance.inputHandler.inputActions.up.IsPressed)
                    {
                        if (GameManager.instance.inputHandler.inputActions.right.IsPressed && HeroController.instance.cState.facingRight)
                        {
                            shouldDiagonal = true;
                        }
                        else if (GameManager.instance.inputHandler.inputActions.left.IsPressed && !HeroController.instance.cState.facingRight)
                        {
                            shouldDiagonal = true;
                        }
                    }
                }
                if (SkillUpgradeActive && !shouldDiagonal)
                {
                    if (GameManager.instance.inputHandler.inputActions.up.IsPressed)
                    {
                        shouldVertical = true;
                    }
                }

                if (shouldDiagonal)
                {
                    SuperdashAngle = -45;
                }
                else if (shouldVertical)
                {
                    SuperdashAngle = -90;
                }
            }));

            fsm.GetState("Direction Wall").AddFirstAction(new Lambda(() =>
            {
                if (DiagonalSuperdash && SkillUpgradeActive)
                {
                    if (GameManager.instance.inputHandler.inputActions.up.IsPressed)
                    {
                        SuperdashAngle = -45;
                    }
                    else if (GameManager.instance.inputHandler.inputActions.down.IsPressed)
                    {
                        SuperdashAngle = 45;
                    }
                }
            }));

            fsm.GetState("Left").AddLastAction(new Lambda(() =>
            {
                HeroController.instance.RotateHero(SuperdashAngle);
            }));
            fsm.GetState("Right").AddLastAction(new Lambda(() =>
            {
                HeroController.instance.RotateHero(SuperdashAngle);
            }));
            #endregion

            #region Modify Dashing and Cancelable states
            FsmState dashing = fsm.GetState("Dashing");
            FsmState cancelable = fsm.GetState("Cancelable");
            FsmBool zeroLast = fsm.FsmVariables.GetFsmBool("Zero Last Frame");
            FsmFloat zeroTimer = fsm.FsmVariables.GetFsmFloat("Zero Timer");

            void setVelocityVariables()
            {
                float velComponent = Math.Abs(fsm.FsmVariables.GetFsmFloat("Current SD Speed").Value);

                vSpeed.Value = velComponent * (-1) * Mathf.Sin(SuperdashAngle * Mathf.PI / 180);
                hSpeed.Value = velComponent * Mathf.Cos(SuperdashAngle * Mathf.PI / 180) * (HeroController.instance.cState.facingRight ? 1 : -1);
            }

            void monitorDirectionalInputs(bool firstFrame)
            {
                if (!ChangeDirectionInMidair || !SkillUpgradeActive) return;

                // If any button was pressed this frame, we need to update for sure.
                // Otherwise, if any button was released, we only update if there's something being pressed (so they let go of up, and still go up).
                // If no inputs changed, then we don't need to bother, except on the first frame.

                HeroActions ia = InputHandler.Instance.inputActions;
                if (!(ia.left.WasPressed || ia.right.WasPressed || ia.up.WasPressed || ia.down.WasPressed
                    || ia.left.WasReleased || ia.right.WasReleased || ia.up.WasReleased || ia.down.WasReleased
                    || firstFrame)) return;

                bool horizontalPressed = false;
                bool verticalPressed = false;
                if (ia.left.IsPressed && !ia.right.IsPressed)
                {
                    horizontalPressed = true;
                    if (HeroController.instance.cState.facingRight)
                    {
                        HeroController.instance.FaceLeft();
                    }
                    
                }
                else if (!ia.left.IsPressed && ia.right.IsPressed)
                {
                    horizontalPressed = true;
                    if (!HeroController.instance.cState.facingRight)
                    {
                        HeroController.instance.FaceRight();
                    }
                }

                float newSuperdashAngle = 0f;
                if (ia.up.IsPressed && !ia.down.IsPressed)
                {
                    newSuperdashAngle = -90f;
                    verticalPressed = true;
                }
                else if (!ia.up.IsPressed && ia.down.IsPressed)
                {
                    newSuperdashAngle = 90f;
                    verticalPressed = true;
                }

                if (horizontalPressed && DiagonalSuperdash) newSuperdashAngle /= 2f;

                if (horizontalPressed || verticalPressed)
                {
                    HeroController.instance.SetHeroRotation(newSuperdashAngle);
                    SuperdashAngle = newSuperdashAngle;
                    zeroTimer.Value = 0f;
                    setVelocityVariables();
                }
            }

            Lambda setVelocityVariablesAction = new Lambda(setVelocityVariables);

            SetVelocity2d setVel = dashing.GetFirstActionOfType<SetVelocity2d>();
            setVel.x = hSpeed;
            setVel.y = vSpeed;

            DecideToStopSuperdash decideToStop = new DecideToStopSuperdash(hSpeed, vSpeed, zeroLast);
            LambdaEveryFrameB turnInMidair = new LambdaEveryFrameB(monitorDirectionalInputs);

            dashing.Actions = new FsmStateAction[]
            {
                    setVelocityVariablesAction,
                    dashing.Actions[0], // Stop if speed is zero
                    dashing.Actions[1], // Move to cancelable after enough time
                    setVel,
                    dashing.Actions[3], // Not affected by gravity
                    dashing.Actions[4], // (same, sort of)
                    decideToStop,
                    dashing.Actions[7], // Check if speed has been zero for long enough to stop
                    dashing.Actions[8], // (same as above)
            };

            cancelable.Actions = new FsmStateAction[]
            {
                    cancelable.Actions[0], // Cancel if pressed Jump
                    setVel,
                    cancelable.Actions[2], // Cancel if pressed Superdash
                    decideToStop,
                    cancelable.Actions[5], // Check if speed has been zero for long enough to stop
                    cancelable.Actions[6], // (same as above)
                    turnInMidair,
            };
            #endregion

            #region Reset Vertical Charge variable
            fsm.GetState("Air Cancel").AddFirstAction(new Lambda(() =>
            {
                ResetSuperdashAngle();
            }));
            fsm.GetState("Cancel").AddFirstAction(new Lambda(() =>
            {
                // Called on scene change
                ResetSuperdashAngle();
            }));
            fsm.GetState("Hit Wall").AddFirstAction(new Lambda(() =>
            {
                ResetSuperdashAngle();
            }));
            #endregion
        }
    }
}