using System.Collections.Generic;
using System.Linq;
using UI.Windows;

namespace Services.Windows
{
    public class WindowService : IWindowService
    {
        private Dictionary<WindowId,WindowBase> _windows;

        public void AddWindows(WindowBase[] windowBases)
        {
            _windows = windowBases
                .ToDictionary(x => x.WindowId, x => x);
            
            _windows[WindowId.Gear].Close();
        }

        public void Open(WindowId windowId)
        {
            _windows[windowId].Open();
        }

        public void Close(WindowId windowId) =>
            _windows[windowId].Close();
    }
}