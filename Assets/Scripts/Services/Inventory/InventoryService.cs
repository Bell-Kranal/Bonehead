using System.Collections.Generic;
using Data.PersistentProgress;
using Inventory;
using StaticData;
using UnityEngine;

namespace Services
{
    public class InventoryService : IInventoryService
    {
        private readonly IInventoryStaticDataService _inventoryStaticDataService;
        private readonly IPersistentProgress _progress;

        private IItem _lastRandomItem;
        private int _numberOfCoincidences;

        public InventoryService(IInventoryStaticDataService inventoryStaticDataService, IPersistentProgress progress)
        {
            _progress = progress;
            _inventoryStaticDataService = inventoryStaticDataService;

            _lastRandomItem = new Item(ItemId.None);
            _numberOfCoincidences = 0;
        }
        
        public KeyValuePair<IItem, IItem> GetItems()
        {
            InventoryItemStaticData itemStaticData = _inventoryStaticDataService.GetRandomItem();

            CheckCoincidences(ref itemStaticData);
            
            IItem item = new Item();
            item.ItemId = itemStaticData.ItemId;
            item.Sprite = itemStaticData.ItemSprite;
            item.Value = Random.Range(1, 15);
            
            _lastRandomItem = item;

            IItem currentItem = _progress.PlayerProgress.GetCurrentItem(item.ItemId) ?? new Item(item.ItemId);

            return new KeyValuePair<IItem, IItem>(currentItem, item);
        }

        private void CheckCoincidences(ref InventoryItemStaticData itemStaticData)
        {
            if (CurrentItemAndLastIsEquals(itemStaticData))
            {
                _numberOfCoincidences++;
            }

            if (_numberOfCoincidences == 3)
            {
                _numberOfCoincidences = 0;
                while (CurrentItemAndLastIsEquals(itemStaticData))
                {
                    itemStaticData = _inventoryStaticDataService.GetRandomItem();
                }
            }
        }

        public void EquipLastRandomItem() =>
            _progress.PlayerProgress.SetItem(_lastRandomItem);

        public int GetLastItemValue() =>
            _lastRandomItem.Value;
        
        public ItemId GetLastItemId() =>
            _lastRandomItem.ItemId;

        private bool CurrentItemAndLastIsEquals(InventoryItemStaticData itemStaticData) =>
            itemStaticData.ItemId.Equals(_lastRandomItem.ItemId);
    }
}