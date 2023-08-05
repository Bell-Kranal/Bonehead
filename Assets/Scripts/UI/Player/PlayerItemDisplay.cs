using System;
using Inventory;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Player
{
    [Serializable]
    public struct PlayerItemDisplay
    {
        public ItemId ItemId;
        public TMP_Text Text;
        public Image Image;
        public Sprite DefaultSprite;
    }
}