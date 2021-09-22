﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;
using ItemChanger.Components;
using ItemChanger.FsmStateActions;
using ItemChanger.Util;
using ItemChanger.Extensions;
using UnityEngine.SceneManagement;

namespace ItemChanger.Locations.SpecialLocations
{
    /// <summary>
    /// Location for modifying the unique Grimmkin spawn of a scene.
    /// </summary>
    public class GrimmkinLocation : AutoLocation
    {
        public int grimmkinLevel;

        protected override void OnLoad()
        {
            Events.AddFsmEdit(sceneName, new("Control"), EditFlamebearerControl);
            Events.AddFsmEdit(sceneName, new("Flamebearer Spawn", "Spawn Control"), EditFlamebearerSpawn);
        }

        protected override void OnUnload()
        {
            Events.RemoveFsmEdit(sceneName, new("Control"), EditFlamebearerControl);
            Events.RemoveFsmEdit(sceneName, new("Flamebearer Spawn", "Spawn Control"), EditFlamebearerSpawn);
        }

        public override GiveInfo GetGiveInfo()
        {
            var info = base.GetGiveInfo();
            info.MessageType = MessageType.Corner;
            return info;
        }

        private void EditFlamebearerControl(PlayMakerFSM fsm)
        {
            if (!fsm.gameObject.name.StartsWith("Flamebearer")) return;

            FsmState init = fsm.GetState("Init");
            init.Actions[2] = new SetIntValue
            {
                intVariable = ((GetPlayerDataInt)init.Actions[2]).storeValue,
                intValue = grimmkinLevel
            };
        }

        private void EditFlamebearerSpawn(PlayMakerFSM fsm)
        {
            FsmState state = fsm.GetState("State");
            FsmState get = fsm.GetState("Get");

            // Override Grimmchild level check
            state.ClearTransitions();
            state.AddTransition("FINISHED", $"Level {grimmkinLevel}");
            state.AddTransition("KILLED", "Do Nothing");
            bool Check()
            {
                return Placement.AllObtained() || !GrimmchildRequirement();
            }

            state.Actions = new FsmStateAction[]
            {
                new BoolTestMod(Check, (BoolTest)state.Actions[0])
            };

            get.Actions = new FsmStateAction[]
            {
                get.Actions[6], // set Activated--not used by IC, but preserves grimmkin status if IC is disabled
                new AsyncLambda((callback) => GiveAll(callback)),
            };
        }

        public bool GrimmchildRequirement()
        {
            return PlayerData.instance.GetBool(nameof(PlayerData.equippedCharm_40)) && PlayerData.instance.GetInt(nameof(PlayerData.grimmChildLevel)) >= grimmkinLevel;
        }

    }
}