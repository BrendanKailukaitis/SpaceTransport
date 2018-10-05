using System;
using System.Windows;
using SpaceTransport.Scripts.Interfaces;

namespace SpaceTransport.Scripts.Managers
{
    public static class WindowManager
    {
        public static void CloseWindow(Guid id)
        {
            foreach (Window window in  Application.Current.Windows)
            {
                if (window.DataContext is IRequireViewIdentification wId && wId.ViewGuid.Equals(id))
                {
                  window.Close();  
                }
            }
        }
    }
}