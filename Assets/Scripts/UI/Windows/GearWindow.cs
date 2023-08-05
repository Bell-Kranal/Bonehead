using System.Collections.Generic;
using Inventory;
using Services;
using UI.Gear;
using UnityEngine;
using Zenject;

namespace UI.Windows
{
    public sealed class GearWindow : WindowBase
    {
        [SerializeField] private GearDisplay _gearDisplay;
        
        private IInventoryService _inventoryService;

        [Inject]
        private void Construct(IInventoryService inventoryService) =>
            _inventoryService = inventoryService;

        public override void Open()
        {
            KeyValuePair<IItem,IItem> items = _inventoryService.GetItems();

            _gearDisplay.SetInformation(items.Key, items.Value);
            gameObject.SetActive(true);
        }
    }
}