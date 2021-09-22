﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HutongGames.PlayMaker;
using ItemChanger.Extensions;

namespace ItemChanger.Locations.SpecialLocations
{
    public class LoreTabletLocation : ObjectLocation
    {
        public string inspectName;
        public string inspectFsm;

        protected override void OnLoad()
        {
            base.OnLoad();
            Events.AddFsmEdit(sceneName, new(inspectName, inspectFsm), DisableInspectRegion);
        }

        protected override void OnUnload()
        {
            base.OnUnload();
            Events.RemoveFsmEdit(sceneName, new(inspectName, inspectFsm), DisableInspectRegion);
        }

        private void DisableInspectRegion(PlayMakerFSM fsm)
        {
            if (fsm.GetState("Init") is FsmState init)
            {
                init.ClearTransitions();
            }

            if (fsm.GetState("Inert") is FsmState inert)
            {
                inert.ClearTransitions();
            }
        }
    }
}