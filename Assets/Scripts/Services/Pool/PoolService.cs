using System.Collections.Generic;
using UI.Coin.FlyingUI;
using UnityEngine;

namespace Services.Pool
{
    public class PoolService<TPool, TParam> : IPoolService<TPool> where TPool : MonoBehaviour, IFlyingUI, IInitializable<TParam>
    {
        private Queue<TPool> _queue;

        public PoolService(int count, Transform parent, TPool prefab, TParam param) =>
            InitializeQueue(count, parent, prefab, param);

        public TPool Item
        {
            get => _queue.Dequeue();
            set => _queue.Enqueue(value);
        }

        private void InitializeQueue(int count, Transform parent, TPool prefab, TParam param)
        {
            _queue = new Queue<TPool>();

            for (int i = 0; i < count; i++)
            {
                TPool item = Object.Instantiate(prefab, parent);
                item.gameObject.SetActive(false);
                item.Init(param);
                
                Item = item;
            }
        }
    }
}