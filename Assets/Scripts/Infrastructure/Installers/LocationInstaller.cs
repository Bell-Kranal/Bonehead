using Data.PersistentProgress;
using Infrastructure.Factories;
using Services.DropCoins_Experience;
using StaticData;
using UI;
using UI.Coin;
using UI.FlyingUI;
using UI.Gear;
using UnityEngine;
using Zenject;

namespace Infrastructure.Installers
{
    public class LocationInstaller : MonoInstaller
    {
        [SerializeField] private Transform _playerSpawnPoint;
        [SerializeField] private Transform _chestSpawnPoint;
        [SerializeField] private Transform _gridSpawnPoint;
        [SerializeField] private Transform _backgroundSpawnPoint;
        [SerializeField] private CoinFlyDisplay coinFlyPrefab;
        [SerializeField] private ExperienceFlyDisplay experienceFlyPrefab;
        [SerializeField] private FlyingSettings _flyingSettings;
        
        public override void InstallBindings()
        {
            ISceneObjectFactory sceneObjectFactory = Container.Resolve<ISceneObjectFactory>();
            IUIFactory uiFactory = Container.Resolve<IUIFactory>();

            sceneObjectFactory.CreatePlayer(_playerSpawnPoint.position);
            sceneObjectFactory.CreateGrid(_gridSpawnPoint.position);
            sceneObjectFactory.CreateChest(_chestSpawnPoint.position);
            sceneObjectFactory.CreateBackground(_backgroundSpawnPoint.position);
            GameObject gameUI = uiFactory.CreateGameUI();
            
            IDropCoinsAndExperience dropCoinsAndExperience =
                new DropCoinsAndExperience(
                    gameUI.GetComponentInChildren<FlyingParent>().transform, 
                    gameUI.GetComponentInChildren<CoinsTarget>().GetComponent<RectTransform>(),
                    gameUI.GetComponentInChildren<ExperienceTarget>().GetComponent<RectTransform>(),
                    coinFlyPrefab,
                    experienceFlyPrefab,
                    _flyingSettings,
                    Container.Resolve<IPersistentProgress>());

            Container.Bind<IDropCoinsAndExperience>().FromInstance(dropCoinsAndExperience).AsSingle();
            gameUI.GetComponentInChildren<GearHandler>().SetIDropCoinsAndExperience(dropCoinsAndExperience);
        }
    }
}