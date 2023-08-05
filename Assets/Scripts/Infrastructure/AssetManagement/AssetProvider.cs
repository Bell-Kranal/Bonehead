using UnityEngine;
using Zenject;

namespace Infrastructure.AssetManagement
{
    public class AssetProvider : IAssetProvider
    {
        private readonly DiContainer _diContainer;

        public AssetProvider(DiContainer diContainer) =>
            _diContainer = diContainer;

        public GameObject Instantiate(string path)
        {
            GameObject gameObject = Resources.Load<GameObject>(path);

            return _diContainer.InstantiatePrefab(gameObject);
        }

        public GameObject Instantiate(string path, Vector3 at)
        {
            GameObject gameObject = Resources.Load<GameObject>(path);

            return _diContainer.InstantiatePrefab(gameObject, at, Quaternion.identity, null);
        }
    }
}