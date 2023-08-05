using System.Collections.Generic;
using Inventory;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Gear
{
    public class GearDisplay : MonoBehaviour
    {
        [SerializeField] private ItemDisplay _currentItemDisplay;
        [SerializeField] private ItemDisplay _newItemDisplay;
        [SerializeField] private Image _arrowImage;
        [SerializeField] private Sprite _greenArrow;
        [SerializeField] private Sprite _redArrow;
        [SerializeField] private TMP_Text _itemIdText;

        private static readonly Dictionary<ItemId, string> _prefixText = new Dictionary<ItemId, string>()
        {
            [ItemId.Weapon] = "ATK: ",
            [ItemId.Shield] = "DEF: ",
            [ItemId.Helmet] = "HP: ",
        };

        public void SetInformation(IItem currentPutOnItem, IItem newItem)
        {
            string currentPrefix = _prefixText[newItem.ItemId];

            _currentItemDisplay.Image.color = currentPutOnItem.Sprite == null ? Color.clear : Color.white;
            _itemIdText.text = newItem.ItemId.ToString();
            
            SetValues(_currentItemDisplay, currentPutOnItem, currentPrefix);
            SetValues(_newItemDisplay, newItem, currentPrefix);
            SetArrow(currentPutOnItem, newItem);
        }

        private void SetArrow(IItem currentPutOnItem, IItem newItem)
        {
            if (currentPutOnItem.Value == newItem.Value)
            {
                _arrowImage.gameObject.SetActive(false);
            }
            else
            {
                _arrowImage.gameObject.SetActive(true);
                _arrowImage.sprite = currentPutOnItem.Value > newItem.Value ? _redArrow : _greenArrow;
            }
        }

        private void SetValues(ItemDisplay itemDisplay, IItem newItem, string currentPrefix)
        {
            itemDisplay.Image.sprite = newItem.Sprite;
            itemDisplay.Text.text = currentPrefix + newItem.Value;
        }
    }
}