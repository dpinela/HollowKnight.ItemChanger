﻿using ItemChanger.Components;
using ItemChanger.Util;

namespace ItemChanger.Locations.SpecialLocations
{
    /// <summary>
    /// Location which prevents DreamPlantOrbs from giving essence and gives items directly after completing the whispering root. Supports a HintBox around the whispering root.
    /// </summary>
    public class WhisperingRootLocation : AutoLocation, ILocalHintLocation
    {
        public bool HintActive { get; set; } = true;

        protected override void OnLoad()
        {
            On.DreamPlant.Awake += DreamPlant_Awake;
            On.DreamPlant.Start += DreamPlant_Start;
            On.DreamPlant.CheckOrbs += DreamPlant_CheckOrbs;
            On.DreamPlant.OnTriggerEnter2D += DreamPlant_OnTriggerEnter2D;
        }

        protected override void OnUnload()
        {
            On.DreamPlant.Awake -= DreamPlant_Awake;
            On.DreamPlant.Start -= DreamPlant_Start;
            On.DreamPlant.CheckOrbs -= DreamPlant_CheckOrbs;
            On.DreamPlant.OnTriggerEnter2D -= DreamPlant_OnTriggerEnter2D;
        }


        public override GiveInfo GetGiveInfo()
        {
            var info = base.GetGiveInfo();
            info.MessageType = MessageType.Corner;
            return info;
        }

        private void DreamPlant_OnTriggerEnter2D(On.DreamPlant.orig_OnTriggerEnter2D orig, DreamPlant self, Collider2D collision)
        {
            orig(self, collision);

            if (self.gameObject.scene.name == sceneName && collision.tag == "Dream Attack" && self.GetCheckOrbRoutine() == null)
            {
                self.SetCheckOrbRoutine(self.StartCoroutine(self.CheckOrbs()));
            }
        }


        private System.Collections.IEnumerator DreamPlant_CheckOrbs(On.DreamPlant.orig_CheckOrbs orig, DreamPlant self)
        {
            yield return orig(self);

            if (self.gameObject.scene.name == sceneName)
            {
                Placement.GiveAll(new GiveInfo 
                {
                    Transform = HeroController.instance.transform,
                    FlingType = flingType,
                    Container = "WhisperingRoot",
                    MessageType = MessageType.Corner,
                });
            }
        }

        private void DreamPlant_Start(On.DreamPlant.orig_Start orig, DreamPlant self)
        {
            orig(self);

            if (self.gameObject.scene.name != sceneName) return;

            if (Placement.AllObtained())
            {
                self.SetCompleted(true);
                self.SetActivated(true);
                var anim = self.GetComponent<tk2dSpriteAnimator>();
                if (anim)
                {
                    anim.Play("Completed");
                }
                if (self.dreamDialogue)
                {
                    self.dreamDialogue.SetActive(true);
                }
            }

            foreach (DreamPlantOrb orb in UnityEngine.Object.FindObjectsOfType<DreamPlantOrb>())
            {
                orb.gameObject.AddComponent<RandomizerDreamPlantOrb>(); // TODO: replace this with an IL hook deleting essence increment from DreamPlantOrb.OnTriggerEnter2D
            }

            if (HintActive && self.dreamDialogue)
            {
                HintBox.Create(self.dreamDialogue.transform, Placement); // the dream plant transform is too high up
            }
        }

        private void DreamPlant_Awake(On.DreamPlant.orig_Awake orig, DreamPlant self)
        {
            if (self.gameObject.scene.name != sceneName)
            {
                orig(self);
                return;
            }

            self.SetSpriteFlash(self.GetComponent<SpriteFlash>());
            self.SetAudioSource(self.GetComponent<AudioSource>());
            self.SetAnim(self.GetComponent<tk2dSpriteAnimator>());
            // removed persistent data events
        }
    }
}
