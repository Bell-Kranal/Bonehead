using UnityEngine;

namespace Inventory
{
    public interface IItem
    {
        public ItemId ItemId { get; set; }
        public int Value { get; set; }
        public Sprite Sprite { get; set; }
    }
}