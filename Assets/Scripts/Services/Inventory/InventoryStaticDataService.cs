using System.Collections.Generic;
using System.Linq;
using StaticData;
using UnityEngine;

namespace Inventory
{
    public class InventoryStaticDataService : IInventoryStaticDataService
    {
        private const string ItemsPath = "StaticData/Inventory/Equipment/";
        
        private readonly List<InventoryItemStaticData> _items;
        
        public InventoryStaticDataService() =>
            _items = Resources
                .LoadAll<InventoryItemStaticData>(ItemsPath)
                .ToList();

        public InventoryItemStaticData GetRandomItem() =>
            _items[Random.Range(0, _items.Count)];
    }
}