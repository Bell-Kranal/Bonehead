using Player;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    [RequireComponent(typeof(Button))]
    public class OpenChestButton : MonoBehaviour
    {
        private Button _button;
        private IPlayerAnimation _playerAnimation;

        [Inject]
        private void Construct(IPlayerAnimation playerAnimation) =>
            _playerAnimation = playerAnimation;

        private void Awake() =>
            _button = GetComponent<Button>();

        private void OnEnable() =>
            _button.onClick.AddListener(OnStartOpenChest);

        private void OnStartOpenChest()
        {
            if (_playerAnimation.CurrentAnimationIsBlink)
            {
                _playerAnimation.PlayOpenChestAnimation();
            }
        }

        private void OnDisable() =>
            _button.onClick.RemoveListener(OnStartOpenChest);
    }
}