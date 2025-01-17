﻿using ItemChanger.Extensions;

namespace ItemChanger.Items
{
    /// <summary>
    /// Item which sets the flags to open the Dirtmouth stag door, and additionally sends the event to open the door if in the corresponding scene.
    /// </summary>
    public class DirtmouthStagItem : AbstractItem
    {
        public override void GiveImmediate(GiveInfo info)
        {
            PlayerData.instance.SetBool(nameof(PlayerData.openedTown), true);
            PlayerData.instance.SetBool(nameof(PlayerData.openedTownBuilding), true);
            if (GameManager.instance.sceneName == "Room_Town_Stag_Station")
            {
                UnityEngine.GameObject.Find("Station Door").LocateFSM("Control").SendEvent("ACTIVATE");
            }
        }

        // TODO: AlreadyObtained may conflict with transition fixes?
    }
}
