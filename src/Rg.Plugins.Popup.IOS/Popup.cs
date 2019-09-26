
using System;
using Rg.Plugins.Popup.IOS.Impl;
using Rg.Plugins.Popup.IOS.Renderers;

namespace Rg.Plugins.Popup
{
    public static class Popup
    {
        internal static event EventHandler OnInitialized;

        internal static bool IsInitialized { get; private set; }

        public static void Init()
        {
            LinkAssemblies();

            IsInitialized = true;
            OnInitialized?.Invoke(null, EventArgs.Empty);
        }

        private static void LinkAssemblies()
        {
            if (false.Equals(true))
            {
#pragma warning disable IDE0067 // Dispose objects before losing scope
                var i = new PopupPlatformIos();
                var r = new PopupPageRenderer();
#pragma warning restore IDE0067 // Dispose objects before losing scope
            }
        }
    }
}
