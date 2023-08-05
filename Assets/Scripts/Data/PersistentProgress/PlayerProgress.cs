using System;
using Inventory;

namespace Data.PersistentProgress
{
    [Serializable]
    public class PlayerProgress
    {
        public InventoryProgress InventoryProgress;
        public PlayerParameters PlayerParameters;
        
        public PlayerProgress()
        {
            InventoryProgress = new InventoryProgress();
            PlayerParameters = new PlayerParameters();
        }

        public IItem GetCurrentItem(ItemId itemId) =>
            InventoryProgress.ForItem(itemId);

        public void SetItem(IItem item) =>
            InventoryProgress.SetItem(item);

        public int GetPower() =>
            InventoryProgress.GetPower();

        public void AddCoins(int coinsCounter) =>
            PlayerParameters.Coins = coinsCounter;

        public void AddExperience(int experienceCounter) =>
            PlayerParameters.Experience = experienceCounter;
    }
}