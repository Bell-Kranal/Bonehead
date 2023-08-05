using UI.Windows;

namespace Services.Windows
{
    public interface IWindowService
    {
        public void AddWindows(WindowBase[] windowBases);
        public void Open(WindowId windowId);
        public void Close(WindowId windowId);
    }
}