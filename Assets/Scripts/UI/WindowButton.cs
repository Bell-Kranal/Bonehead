using System;
using Services.Windows;
using UnityEngine.UI;

namespace UI.Windows
{
    [Serializable]
    public struct WindowButton
    {
        public Button Button;
        public WindowId WindowId;
    }
}