﻿using HutongGames.PlayMaker.Actions;
using ItemChanger.Extensions;

namespace ItemChanger.Locations.SpecialLocations
{
    /// <summary>
    /// ObjectLocation which places a shiny at the end of the Dream Nail sequence that triggers a scene change to the Seer's room. Expects that no other shinies are placed in the Dream Nail sequence.
    /// </summary>
    public class DreamNailLocation : ObjectLocation
    {
        protected override void OnLoad()
        {
            base.OnLoad();
            Events.AddFsmEdit(sceneName, new("Witch Control", "Control"), RemoveSetCollider);
            //Events.AddFsmEdit(sceneName, new("Shiny Control"), EditShiny);
        }

        protected override void OnUnload()
        {
            base.OnUnload();
            Events.RemoveFsmEdit(sceneName, new("Witch Control", "Control"), RemoveSetCollider);
            //Events.RemoveFsmEdit(sceneName, new("Shiny Control"), EditShiny);
        }

        private void RemoveSetCollider(PlayMakerFSM fsm)
        {
            fsm.GetState("Convo Ready").RemoveActionsOfType<SetCollider>(); // not important, but prevents null ref unity logs after destroying Moth NPC object
        }

        /*
         * Moved to tag
        private void EditShiny(PlayMakerFSM fsm)
        {
            fsm.FsmVariables.FindFsmBool("Exit Dream").Value = true;
            fsm.GetState("Fade Pause").AddFirstAction(new Lambda(() =>
            {
                PlayerData.instance.dreamReturnScene = "RestingGrounds_07";
                HeroController.instance.proxyFSM.FsmVariables.GetFsmBool("No Charms").Value = false;
            }));
        }
        */
    }
}
