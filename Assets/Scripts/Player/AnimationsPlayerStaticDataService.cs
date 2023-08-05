using System.Collections.Generic;
using Data;
using Data.StaticData;
using UnityEngine;

namespace Player
{
    public class AnimationsPlayerStaticDataService : IAnimationsPlayerStaticDataService
    {
        private const string AnimationsPath = "StaticData/Player/Animations";
        
        private readonly List<int> _animationHashes;
        
        public AnimationsPlayerStaticDataService() =>
            _animationHashes = Resources
                .Load<AnimationsPlayerStaticData>(AnimationsPath)
                .AnimationNames
                .ToList<int, string>(x => Animator.StringToHash(x));

        public int GetRandomAnimationHash() =>
            _animationHashes[Random.Range(0, _animationHashes.Count)];
    }
}