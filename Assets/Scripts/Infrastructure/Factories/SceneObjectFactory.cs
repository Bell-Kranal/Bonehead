using Infrastructure.AssetManagement;
using Player;
using StaticData;
using UnityEngine;
using Zenject;

namespace Infrastructure.Factories
{
    public class SceneObjectFactory : ISceneObjectFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly DiContainer _diContainer;
        private readonly IClothStaticDataService _clothStaticDataService;

        private IPlayerAnimation _playerAnimation;

        public SceneObjectFactory(IAssetProvider assetProvider, DiContainer diContainer, IClothStaticDataService clothStaticDataService)
        {
            _assetProvider = assetProvider;
            _diContainer = diContainer;
            _clothStaticDataService = clothStaticDataService;
        }

        public GameObject CreateGrid(Vector3 at) =>
            Instantiate(AssetsPath.Grid, at);

        public GameObject CreatePlayer(Vector3 at)
        {
            GameObject instantiatedPlayer = Instantiate(AssetsPath.Player, at);
            
            _playerAnimation = instantiatedPlayer.GetComponent<IPlayerAnimation>();
            _diContainer.Bind<IPlayerAnimation>().FromInstance(_playerAnimation).AsSingle();
            
            return instantiatedPlayer;
        }

        public GameObject CreateChest(Vector3 at)
        {
            GameObject chest = Instantiate(AssetsPath.Chest, at);

            _playerAnimation.Chest = chest.GetComponent<Chest>();
            
            return chest;
        }

        public GameObject CreateBackground(Vector3 at) =>
            Instantiate(AssetsPath.Background, at);

        public GameObject CreateCloth(Vector3 at, Transform parent, Sprite sprite)
        {
            GameObject cloth = _diContainer.InstantiatePrefab(_clothStaticDataService.ForCloth(sprite), at, Quaternion.identity, parent);

            return cloth;
        }

        private GameObject Instantiate(string path, Vector3 at)
        {
            GameObject gameObject = _assetProvider.Instantiate(path, at);
            return gameObject;
        }
    }
}