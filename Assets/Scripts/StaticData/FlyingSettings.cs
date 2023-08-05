using DG.Tweening;
using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(menuName = "StaticData/Fly/Settings", fileName = "FlySettings")]
    public class FlyingSettings : ScriptableObject
    {
        [Min(0f)]
        public Vector2 DelayRange;
        public Vector2 InitialRangePosition;
        public Vector2 InitialRangeRotation;

        [Range(0.2f, 1.5f)]
        public float ScaleDuration;
        [Range(0.5f, 1.5f)]
        public float MoveDuration;
        [Range(0.5f, 1.5f)]
        public float DurationBetweenScaleAndMove;

        public Ease ScaleEase;
        public Ease MoveEase;
    }
}