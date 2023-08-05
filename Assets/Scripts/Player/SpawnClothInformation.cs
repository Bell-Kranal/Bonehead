using System;
using Inventory;
using UnityEngine;

namespace Player
{
    [Serializable]
    public struct SpawnClothInformation
    {
        public ItemId ItemId;
        public Transform SpawnPosition;
        public Transform Parent;
    }
}