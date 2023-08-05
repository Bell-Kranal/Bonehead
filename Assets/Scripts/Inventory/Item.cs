using UnityEngine;

namespace Inventory
{
    public class Item : IItem
    {
        public Item()
        {
            ItemId = ItemId.None;
            Value = 0;
        }

        public Item(ItemId itemId)
        {
            ItemId = itemId;
            Value = 0;
            Sprite = null;
        }

        public ItemId ItemId { get; set; }
        public int Value { get; set; }
        public Sprite Sprite { get; set; }
    }
}