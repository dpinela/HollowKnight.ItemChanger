﻿using System.Reflection;

namespace ItemChanger.Components
{
    /// <summary>
    /// A component which cancels out the increment essence effect of a DreamPlantOrb.
    /// </summary>
    public class RandomizerDreamPlantOrb : MonoBehaviour
    {
        public void Awake()
        {
            orb = gameObject.GetComponent<DreamPlantOrb>();
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player" && canPickup && !removedEssence)
            {
                PlayerData.instance.DecrementInt("dreamOrbs");
                removedEssence = true;
                EventRegister.SendEvent("DREAM ORB COLLECT");
            }
        }

        private DreamPlantOrb orb;
        private bool removedEssence;

        private FieldInfo canPickupField = typeof(DreamPlantOrb).GetField("canPickup", BindingFlags.Instance | BindingFlags.NonPublic);
        private bool canPickup => (bool) canPickupField.GetValue(orb);
    }

}
