using Data.PersistentProgress;
using Services.Pool;
using StaticData;
using UI.Coin;
using UI.FlyingUI;
using UnityEngine;

namespace Services.DropCoins_Experience
{
    public class DropCoinsAndExperience : IDropCoinsAndExperience
    {
        private readonly IPoolService<CoinFlyDisplay> _coins;
        private readonly IPoolService<ExperienceFlyDisplay> _experience;
        private readonly IPersistentProgress _progress;
        private readonly RectTransform _coinsTo;
        private readonly RectTransform _experienceTo;
        private readonly int _coinsCount;
        private readonly int _experienceCount;

        public DropCoinsAndExperience(Transform parent, RectTransform coinsTo, RectTransform experienceTo, CoinFlyDisplay coinFlyPrefab, ExperienceFlyDisplay expPrefab, FlyingSettings flyingSettings, IPersistentProgress progress)
        {
            _coinsCount = 15;
            _experienceCount = 5;
            
            _coins = new PoolService<CoinFlyDisplay, FlyingSettings>(_coinsCount, parent, coinFlyPrefab, flyingSettings);
            _experience = new PoolService<ExperienceFlyDisplay, FlyingSettings>(_experienceCount, parent, expPrefab, flyingSettings);

            _coinsTo = coinsTo;
            _experienceTo = experienceTo;
            _progress = progress;
        }
        
        public void Drop(int coinsCounter)
        {
            if (coinsCounter == 0)
                return;
            
            int experienceCounter;
            
            GoCoins(coinsCounter);
            GoExperience(out experienceCounter);

            _progress.PlayerProgress.AddCoins(coinsCounter);
            _progress.PlayerProgress.AddExperience(experienceCounter);
        }

        private void GoCoins(int coinsCounter)
        {
            for (int i = 0; i < coinsCounter; i++)
            {
                CoinFlyDisplay item = _coins.Item;
                item.Fly(_coinsTo, () => { _coins.Item = item; });
            }
        }

        private void GoExperience(out int experienceCounter)
        {
            experienceCounter = Random.Range(0, _experienceCount + 1);

            for (int i = 0; i < experienceCounter; i++)
            {
                ExperienceFlyDisplay item = _experience.Item;
                item.Fly(_experienceTo, () => { _experience.Item = item; });
            }
        }
    }
}