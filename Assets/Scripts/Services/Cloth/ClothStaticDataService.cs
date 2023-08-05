using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace StaticData
{
    public class ClothStaticDataService : IClothStaticDataService
    {
        private const string StaticDataClothes = "StaticData/Inventory/Clothes/";
        
        private readonly Dictionary<Sprite,GameObject> _clothes;

        public ClothStaticDataService()
        {
            _clothes = Resources
                .LoadAll<ClothStaticData>(StaticDataClothes)
                .ToDictionary(x => x.Sprite, x => x.GameObject);
        }

        public GameObject ForCloth(Sprite sprite) =>
            _clothes.TryGetValue(sprite, out GameObject gameObject) ? gameObject : null;
    }
}