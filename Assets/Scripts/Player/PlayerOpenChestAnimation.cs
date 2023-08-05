using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Animator))]
    public class PlayerOpenChestAnimation : MonoBehaviour, IPlayerAnimation
    {
        public Chest Chest { get; set; }
        
        private static readonly int OpenChest = Animator.StringToHash("OpenChest");
        private const string Blink = "Blink";
        
        private Animator _animator;

        public bool CurrentAnimationIsBlink => _animator.GetCurrentAnimatorStateInfo(0).IsName(Blink); 

        private void Awake() =>
            _animator = GetComponent<Animator>();
        
        public void PlayOpenChestAnimation() =>
            _animator.SetTrigger(OpenChest);

        public void OnBeginOpenChest() =>
            Chest.OpenChest();
    }
}