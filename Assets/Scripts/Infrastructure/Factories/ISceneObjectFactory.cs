using UnityEngine;

namespace Infrastructure.Factories
{
    public interface ISceneObjectFactory : IGameFactory
    {
        public GameObject CreateGrid(Vector3 at);
        public GameObject CreatePlayer(Vector3 at);
        public GameObject CreateChest(Vector3 at);
        public GameObject CreateBackground(Vector3 at);
        public GameObject CreateCloth(Vector3 at, Transform parent, Sprite sprite);
    }
}