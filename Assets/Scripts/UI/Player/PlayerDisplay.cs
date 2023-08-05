using Data.PersistentProgress;
using Inventory;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.Player
{
    public class PlayerDisplay : MonoBehaviour
    {
        [SerializeField] private TMP_Text _powerText;
        [SerializeField] private PlayerItemDisplay[] _playerItemDisplays;
        [SerializeField] private float _transparency;
        
        private const string Zero = "0";
        private const string Power = "Power: ";

        private IPersistentProgress _progress;

        [Inject]
        private void Construct(IPersistentProgress progress) =>
            _progress = progress;

        private void OnEnable() =>
            _progress.PlayerProgress.InventoryProgress.InventoryUpdated += OnInventoryUpdated;

        private void OnInventoryUpdated(ItemId itemId)
        {
            PlayerItemDisplay playerItemDisplay = FindItemDisplay(itemId);
            SetValues(playerItemDisplay.Text, playerItemDisplay.Image, itemId, playerItemDisplay.DefaultSprite);
            
            _powerText.text = Power + _progress.PlayerProgress.GetPower();   
        }

        private PlayerItemDisplay FindItemDisplay(ItemId itemId)
        {
            for (int i = 0; i < _playerItemDisplays.Length; i++)
            {
                if (itemId.Equals(_playerItemDisplays[i].ItemId))
                {
                    return _playerItemDisplays[i];
                }
            }
            
            return default;
        }

        private void SetValues(TMP_Text text, Image image, ItemId itemId, Sprite defaultSprite)
        {
            IItem item = _progress.PlayerProgress.GetCurrentItem(itemId);
            if (item == null)
            {
                text.text = Zero;
                image.sprite = defaultSprite;
                image.color = new Color(1f, 1f, 1f, _transparency);
                return;
            }
            
            image.color = Color.white;
            text.text = item.Value.ToString();
            image.sprite = item.Sprite;
        }

        private void OnDisable() =>
            _progress.PlayerProgress.InventoryProgress.InventoryUpdated -= OnInventoryUpdated;
    }
}