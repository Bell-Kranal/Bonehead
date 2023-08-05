using Data.PersistentProgress;
using Services;
using Services.DropCoins_Experience;
using Services.Windows;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.Gear
{
    public class GearHandler : MonoBehaviour
    {
        [SerializeField] private Button _equipButton;
        [SerializeField] private Button _dropButton;
        
        private IInventoryService _inventoryService;
        private IWindowService _windowService;
        private IDropCoinsAndExperience _dropCoinsAndExperience;
        private IPersistentProgress _progress;

        [Inject]
        private void Construct(IInventoryService inventoryService, IWindowService windowService, IPersistentProgress progress)
        {
            _progress = progress;
            _windowService = windowService;
            _inventoryService = inventoryService;
        }

        public void SetIDropCoinsAndExperience(IDropCoinsAndExperience dropCoinsAndExperience) =>
            _dropCoinsAndExperience = dropCoinsAndExperience;

        private void OnEnable()
        {
            _equipButton.onClick.AddListener(() =>
            {
                _dropCoinsAndExperience.Drop(_progress.PlayerProgress.GetCurrentItem(_inventoryService.GetLastItemId()).Value);
                _inventoryService.EquipLastRandomItem();
                _windowService.Close(WindowId.Gear);
            });
            
            _dropButton.onClick.AddListener(() =>
            {
                _dropCoinsAndExperience.Drop(_inventoryService.GetLastItemValue());
                _windowService.Close(WindowId.Gear);
            });
        }

        private void OnDisable()
        {
            _equipButton.onClick.RemoveListener(() =>
            {
                _dropCoinsAndExperience.Drop(_progress.PlayerProgress.GetCurrentItem(_inventoryService.GetLastItemId()).Value);
                _dropCoinsAndExperience.Drop(_inventoryService.GetLastItemValue());
                _inventoryService.EquipLastRandomItem();
                _windowService.Close(WindowId.Gear);
            });
            
            _dropButton.onClick.RemoveListener(() =>
            {
                _dropCoinsAndExperience.Drop(_inventoryService.GetLastItemValue());
                _windowService.Close(WindowId.Gear);
            });
        }
    }
}