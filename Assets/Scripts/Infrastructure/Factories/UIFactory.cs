using Infrastructure.AssetManagement;
using Services.Windows;
using UI.Windows;
using UnityEngine;

namespace Infrastructure.Factories
{
    public class UIFactory : IUIFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly IWindowService _windowService;

        public UIFactory(IAssetProvider assetProvider, IWindowService windowService)
        {
            _assetProvider = assetProvider;
            _windowService = windowService;
        }

        public GameObject CreateRootUI()
        {
            GameObject rootUI = _assetProvider.Instantiate(AssetsPath.RootUI);
            rootUI.transform.parent = null;
            
            Object.DontDestroyOnLoad(rootUI);
            return rootUI;
        }

        public GameObject CreateGameUI()
        {
            GameObject ui = _assetProvider.Instantiate(AssetsPath.GameUI);

            _windowService.AddWindows(ui.GetComponentsInChildren<WindowBase>());
            
            return ui;
        }
    }
}