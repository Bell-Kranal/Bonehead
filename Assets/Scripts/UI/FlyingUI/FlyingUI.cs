using System;
using DG.Tweening;
using Services.Pool;
using StaticData;
using UI.Coin.FlyingUI;
using UnityEngine;
using Random = UnityEngine.Random;

namespace UI.FlyingUI
{
    public abstract class FlyingUI : MonoBehaviour, IFlyingUI, IInitializable<FlyingSettings>
    {
        private RectTransform _rectTransform;
        private FlyingSettings _flyingSettings;

        public void Init(FlyingSettings param)
        {
            _flyingSettings = param;
            Reset();
        }

        private void Awake() =>
            _rectTransform = GetComponent<RectTransform>();

        public virtual void Fly(RectTransform to, Action flyEnd = null)
        {
            gameObject.SetActive(true);

            float delay = Random.Range(_flyingSettings.DelayRange.x, _flyingSettings.DelayRange.y);
            
            transform
                .DOScale(Vector3.one, _flyingSettings.ScaleDuration)
                .SetDelay(delay)
                .SetEase(Ease.OutBack);

            _rectTransform.transform
                .DOMove(to.position, _flyingSettings.MoveDuration)
                .SetDelay(delay + _flyingSettings.DurationBetweenScaleAndMove)
                .SetEase(Ease.Flash)
                .OnComplete(() =>
                {
                    Reset(); 
                    flyEnd?.Invoke();
                });
        }

        protected virtual void Reset()
        {
            transform.localScale = Vector3.zero;
            _rectTransform.anchoredPosition = new Vector2(
                Random.Range(_flyingSettings.InitialRangePosition.x, _flyingSettings.InitialRangePosition.y), 
                Random.Range(_flyingSettings.InitialRangePosition.x, _flyingSettings.InitialRangePosition.y));
            
            _rectTransform.eulerAngles = new Vector3(
                0f, 
                0f, 
                Random.Range(
                    _flyingSettings.InitialRangeRotation.x,
                    _flyingSettings.InitialRangeRotation.y)
            );
            
            gameObject.SetActive(false);
        }
    }
}