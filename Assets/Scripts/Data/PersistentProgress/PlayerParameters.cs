using System;

namespace Data.PersistentProgress
{
    [Serializable]
    public class PlayerParameters
    {
        private int _coins;
        private int _level;
        private int _experience;

        public event Action<int> CoinsChanged;
        public event Action<int> LevelChanged;
        public event Action<int, int> ExperienceChanged;

        public PlayerParameters()
        {
            _coins = 0;
            _level = 1;
            _experience = 0;
        }

        public int Coins
        {
            get => _coins;
            
            set
            {
                _coins += value;
                CoinsChanged?.Invoke(_coins);
            }
        }
        
        public int Level
        {
            get => _level;
            
            set
            {
                _level += value;
                LevelChanged?.Invoke(_level);
            }
        }
        
        public int Experience
        {
            get => _experience;
            
            set
            {
                _experience += value;
                if (_experience >= MaxExperience)
                {
                    _experience -= MaxExperience;
                    Level = 1;
                }
                ExperienceChanged?.Invoke(_experience, MaxExperience);
            }
        }

        public int MaxExperience => Level * 5;
    }
}