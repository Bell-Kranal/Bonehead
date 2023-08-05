using System.Collections.Generic;
using Data.PersistentProgress;
using Infrastructure.Factories;
using Inventory;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerClothSpawner : MonoBehaviour
    {
        [SerializeField] private SpawnClothInformation[] _spawnClothInformations;
        
        private IPersistentProgress _persistentProgress;
        private Dictionary<ItemId, GameObject> _spawnedClothes;
        private ISceneObjectFactory _sceneObjectFactory;

        [Inject]
        private void Construct(IPersistentProgress persistentProgress, ISceneObjectFactory sceneObjectFactory)
        {
            _sceneObjectFactory = sceneObjectFactory;
            _persistentProgress = persistentProgress;
            _spawnedClothes = new Dictionary<ItemId, GameObject>();
        }

        private void OnEnable() =>
            _persistentProgress.PlayerProgress.InventoryProgress.InventoryUpdated += OnInventoryUpdated;

        private void OnInventoryUpdated(ItemId itemId)
        {
            if (_spawnedClothes.TryGetValue(itemId, out GameObject cloth))
            {
                Destroy(cloth);
            }
            
            
            SpawnClothInformation spawnClothInformation = FindInformation(itemId);
            IItem currentItem = _persistentProgress.PlayerProgress.GetCurrentItem(itemId);
            
            _spawnedClothes[itemId] = _sceneObjectFactory.CreateCloth(spawnClothInformation.SpawnPosition.position, spawnClothInformation.Parent, currentItem.Sprite);
        }

        private SpawnClothInformation FindInformation(ItemId itemId)
        {
            for (int i = 0; i < _spawnClothInformations.Length; i++)
            {
                if (itemId.Equals(_spawnClothInformations[i].ItemId))
                {
                    return _spawnClothInformations[i];
                }
            }

            return default;
        }

        private void OnDisable() =>
            _persistentProgress.PlayerProgress.InventoryProgress.InventoryUpdated -= OnInventoryUpdated;
    }
}