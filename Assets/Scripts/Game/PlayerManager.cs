namespace Game
{
    using System.Collections.Generic;
    using Blueprints;
    using UnityEngine;

    public class PlayerManager : MonoBehaviour
    {
        public List<Upgrade> upgrades = new();

        public bool AddUpgrade(UpgradeRecord newRecord, int slot, int prevSlot = -1)
        {
            if (upgrades[slot].HasUpgrade())
            {
                // Add upgrade from shop
                if (prevSlot == -1) return false;

                // Switch upgrade

                UpgradeRecord slotRecord = upgrades[slot].UpgradeRecord;
                upgrades[prevSlot].UpgradeRecord = slotRecord;
            }
            
            upgrades[slot].UpgradeRecord = newRecord;
            return true;
        }
    }
}