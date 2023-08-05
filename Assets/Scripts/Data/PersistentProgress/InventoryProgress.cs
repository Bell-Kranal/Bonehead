using System;
using System.Collections.Generic;
using Inventory;

namespace Data.PersistentProgress
{
    [Serializable]
    public class InventoryProgress
    {
        public event Action<ItemId> InventoryUpdated;
        
        private Dictionary<ItemId, IItem> _putOnItems;

        public InventoryProgress()
        {
            _putOnItems = new Dictionary<ItemId, IItem>();
        }

        public IItem ForItem(ItemId itemId) =>
            _putOnItems.TryGetValue(itemId, out IItem item) ? item : new Item();

        public void SetItem(IItem inputItem)
        {
            if (_putOnItems.TryGetValue(inputItem.ItemId, out IItem item))
            {
                item.Value = inputItem.Value;
                item.Sprite = inputItem.Sprite;
            }
            else
            {
                _putOnItems[inputItem.ItemId] = inputItem;
            }
            
            InventoryUpdated?.Invoke(inputItem.ItemId);
        }

        public int GetPower()
        {
            _putOnItems.TryGetValue(ItemId.Helmet, out IItem hp);
            _putOnItems.TryGetValue(ItemId.Weapon, out IItem atk);
            _putOnItems.TryGetValue(ItemId.Shield, out IItem def);

            int result = 0;

            if (hp != null) result = hp.Value;
            if (def != null) result += def.Value;
            if (atk != null) result += atk.Value;
            
            return result;
        }
    }
}