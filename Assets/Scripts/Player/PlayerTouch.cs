using UnityEngine;
using Zenject;

namespace Player
{
    [RequireComponent(typeof(Animator))]
    public class PlayerTouch : MonoBehaviour
    {
        private const string Blink = "Blink";
        
        private IAnimationsPlayerStaticDataService _animationsPlayerStaticDataService;
        private Animator _animator;

        [Inject]
        private void Construct(IAnimationsPlayerStaticDataService animationsPlayerStaticDataService) =>
            _animationsPlayerStaticDataService = animationsPlayerStaticDataService;

        private bool CurrentAnimationIsIdle => _animator.GetCurrentAnimatorStateInfo(0).IsName(Blink);

        private void Awake() =>
            _animator = GetComponent<Animator>();

        private void OnMouseDown()
        {
            if (CurrentAnimationIsIdle)
            {
                _animator.Play(_animationsPlayerStaticDataService.GetRandomAnimationHash());
            }
        }
    }
}