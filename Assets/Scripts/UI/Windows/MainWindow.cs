using Data.PersistentProgress;
using UnityEngine;
using Zenject;

namespace UI.Windows
{
    public sealed class MainWindow : WindowBase
    {
        [SerializeField] private CoinsDisplay _coinsDisplay;
        [SerializeField] private ExperienceDisplay _experienceDisplay;
        [SerializeField] private LevelDisplay _levelDisplay;
        
        private IPersistentProgress _progress;

        [Inject]
        private void Construct(IPersistentProgress progress) =>
            _progress = progress;

        protected override void Initialize()
        {
            _coinsDisplay.UpdateText(_progress.PlayerProgress.PlayerParameters.Coins);
            _levelDisplay.UpdateText(_progress.PlayerProgress.PlayerParameters.Level);
            _experienceDisplay.UpdateText(_progress.PlayerProgress.PlayerParameters.Experience, _progress.PlayerProgress.PlayerParameters.MaxExperience);
        }

        protected override void Subscribe()
        {
            _progress.PlayerProgress.PlayerParameters.CoinsChanged += _coinsDisplay.UpdateText;
            _progress.PlayerProgress.PlayerParameters.ExperienceChanged += _experienceDisplay.UpdateText;
            _progress.PlayerProgress.PlayerParameters.LevelChanged += _levelDisplay.UpdateText;
        }
        
        protected override void Describe()
        {
            _progress.PlayerProgress.PlayerParameters.CoinsChanged -= _coinsDisplay.UpdateText;
            _progress.PlayerProgress.PlayerParameters.ExperienceChanged += _experienceDisplay.UpdateText;
            _progress.PlayerProgress.PlayerParameters.LevelChanged += _levelDisplay.UpdateText;
        }
    }
}