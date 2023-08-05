using System;
using Services.Windows;
using UnityEngine;

namespace UI.Windows
{
    public abstract class WindowBase : MonoBehaviour
    {
        public WindowId WindowId;

        private void Awake() =>
            Initialize();

        public virtual void Open() =>
            gameObject.SetActive(true);

        public virtual void Close() =>
            gameObject.SetActive(false);

        protected virtual void OnEnable() =>
            Subscribe();

        protected void OnDisable() =>
            Describe();

        protected virtual void Initialize() { }
        protected virtual void Subscribe() { }
        protected virtual void Describe() { }
    }
}