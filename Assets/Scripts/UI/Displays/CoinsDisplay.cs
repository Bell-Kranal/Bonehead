using TMPro;
using UnityEngine;

namespace UI.Windows
{
    public class CoinsDisplay : MonoBehaviour
    {
        [SerializeField] private TMP_Text _coins;
        
        public void UpdateText(int newValue) =>
            _coins.text = newValue.ToString();
    }
}