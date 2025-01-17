﻿using ItemChanger.Extensions;

namespace ItemChanger.Modules
{
    [DefaultModule]
    public class LeftCityChandelier : Module
    {
        public override void Initialize()
        {
            Events.AddSceneChangeEdit(SceneNames.Ruins1_05, MakeChandelierPogoable);
        }

        public override void Unload()
        {
            Events.RemoveSceneChangeEdit(SceneNames.Ruins1_05, MakeChandelierPogoable);
        }

        private void MakeChandelierPogoable(Scene to)
        {
            GameObject chandelier = to.FindGameObject("ruind_dressing_light_02 (10)");
            chandelier.transform.SetPositionX(chandelier.transform.position.x - 2);
            chandelier.GetComponent<NonBouncer>().active = false;
        }
    }
}
