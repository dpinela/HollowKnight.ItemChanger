﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;
using ItemChanger.Components;
using ItemChanger.FsmStateActions;
using ItemChanger.Util;
using ItemChanger.Extensions;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ItemChanger.Locations.SpecialLocations
{
    public class NailmasterLocation : AutoLocation
    {
        public string objectName;
        public string fsmName;

        protected override void OnLoad()
        {
            Events.AddFsmEdit(sceneName, new(objectName, fsmName), EditNailmasterConvo);
            Events.OnLanguageGet += OnLanguageGet;
        }

        protected override void OnUnload()
        {
            Events.RemoveFsmEdit(sceneName, new(objectName, fsmName), EditNailmasterConvo);
            Events.OnLanguageGet -= OnLanguageGet;
        }

        private void EditNailmasterConvo(PlayMakerFSM fsm)
        {
            FsmState convo = fsm.GetState("Convo Choice");
            FsmState getMsg = fsm.GetState("Get Msg");
            FsmState fade = fsm.GetState("Fade Back");

            FsmStateAction test = new BoolTestMod(Placement.AllObtained, null, "REOFFER");
            FsmStateAction give = new AsyncLambda(GiveAllAsync(fsm.transform), "GET ITEM MSG END");

            convo.Actions[objectName == "NM Sheo NPC" ? 2 : 1] = test;

            getMsg.Actions = new FsmStateAction[]
            {
                    getMsg.Actions[0],
                    getMsg.Actions[1],
                    getMsg.Actions[2],
                    give,
            };
        }

        private void OnLanguageGet(LanguageGetArgs args)
        {
            if (args.sheet == "Prompts" && args.convo == "NAILMASTER_FREE") args.current = Placement.GetUIName();
        }
    }
}