using TMPro;
using UnityEngine;

namespace UI.Windows
{
    public class LevelDisplay : MonoBehaviour
    {
        [SerializeField] private TMP_Text _level;
        
        public void UpdateText(int newValue) =>
            _level.text = newValue.ToString();
    }
}