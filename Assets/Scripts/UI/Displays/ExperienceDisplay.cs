using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Windows
{
    public class ExperienceDisplay : MonoBehaviour
    {
        [SerializeField] private Image _imageFill;
        [SerializeField] private TMP_Text _text;

        private const string Symbol = " / ";
        
        public void UpdateText(int newValue, int maxValue)
        {
            _text.text = newValue + Symbol + maxValue;
            _imageFill.fillAmount = (float)newValue / maxValue;
        }
    }
}