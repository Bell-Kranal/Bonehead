using Inventory;
using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(menuName = "StaticData/Player/InventoryItem", fileName = "Item")]
    public class InventoryItemStaticData : ScriptableObject
    {
        public ItemId ItemId;
        public Sprite ItemSprite;
        public int Value;
    }
}
