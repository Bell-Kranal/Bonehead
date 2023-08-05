using Data.PersistentProgress;
using Infrastructure.AssetManagement;
using Infrastructure.Factories;
using Inventory;
using Player;
using Services;
using Services.Windows;
using StaticData;
using UnityEngine;
using Zenject;

namespace Infrastructure.States
{
    public class BootstrapState : IPayloadState<string>
    {
        private readonly DiContainer _diContainer;
        private readonly IGameStateMachine _gameStateMachine;

        private SceneLoader _sceneLoader;
        private IUIFactory _gameFactory;

        public BootstrapState(DiContainer diContainer, IGameStateMachine gameStateMachine)
        {
            _diContainer = diContainer;
            _gameStateMachine = gameStateMachine;

            RegisterServices();
        }

        public void Enter(string sceneName)
        {
            GameObject rootUI = _gameFactory.CreateRootUI();

            _sceneLoader = new SceneLoader(
                rootUI.GetComponentInChildren<LoadingSlider>(), 
                rootUI.GetComponentInChildren<LoadingScreen>()
                );
            
            _sceneLoader.Load(sceneName);
        }

        public void Exit() { }

        private void RegisterServices()
        {
            IAssetProvider assetProvider = new AssetProvider(_diContainer);
            IAnimationsPlayerStaticDataService animationsPlayerStaticDataService = new AnimationsPlayerStaticDataService();
            IInventoryStaticDataService inventoryStaticDataService = new InventoryStaticDataService();
            IClothStaticDataService clothStaticDataService = new ClothStaticDataService();
            IWindowService windowService = new WindowService();
            IPersistentProgress persistentProgress = new PersistentProgress();
            ISceneObjectFactory sceneObjectFactory = new SceneObjectFactory(assetProvider, _diContainer, clothStaticDataService);
            IInventoryService inventoryService = new InventoryService(inventoryStaticDataService, persistentProgress);

            persistentProgress.PlayerProgress = new PlayerProgress();
            _gameFactory = new UIFactory(assetProvider, windowService);

            _diContainer.Bind<IUIFactory>().FromInstance(_gameFactory).AsSingle();
            _diContainer.Bind<ISceneObjectFactory>().FromInstance(sceneObjectFactory).AsSingle();
            _diContainer.Bind<IAnimationsPlayerStaticDataService>().FromInstance(animationsPlayerStaticDataService).AsSingle();
            _diContainer.Bind<IInventoryStaticDataService>().FromInstance(inventoryStaticDataService).AsSingle();
            _diContainer.Bind<IWindowService>().FromInstance(windowService).AsSingle();
            _diContainer.Bind<IPersistentProgress>().FromInstance(persistentProgress).AsSingle();
            _diContainer.Bind<IInventoryService>().FromInstance(inventoryService).AsSingle();
            _diContainer.Bind<IClothStaticDataService>().FromInstance(clothStaticDataService).AsSingle();
        }
    }
}