using System.Collections.Generic;
using Inventory;

namespace Services
{
    public interface IInventoryService
    {
        public KeyValuePair<IItem, IItem> GetItems();
        public void EquipLastRandomItem();
        public int GetLastItemValue();
        public ItemId GetLastItemId();
    }
}