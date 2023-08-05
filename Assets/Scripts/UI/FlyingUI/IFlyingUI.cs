using System;
using UnityEngine;

namespace UI.Coin.FlyingUI
{
    public interface IFlyingUI
    {
        public void Fly(RectTransform to, Action flyEnd = null);
    }
}