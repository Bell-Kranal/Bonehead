using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(menuName = "StaticData/Inventory/Cloth", fileName = "Cloth")]
    public class ClothStaticData : ScriptableObject
    {
        public Sprite Sprite;
        public GameObject GameObject;
    }
}