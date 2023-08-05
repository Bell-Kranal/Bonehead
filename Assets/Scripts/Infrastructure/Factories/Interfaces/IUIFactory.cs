using UnityEngine;

namespace Infrastructure.Factories
{
    public interface IUIFactory : IGameFactory
    {
        public GameObject CreateGameUI();
        public GameObject CreateRootUI();
    }
}