using System;
using System.Linq;
using Android.Content;
using Android.OS;
using Rg.Plugins.Popup.Droid.Impl;
using Rg.Plugins.Popup.Droid.Renderers;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace Rg.Plugins.Popup
{
    public static class Popup
    {
        internal static event EventHandler OnInitialized;

        internal static bool IsInitialized { get; private set; }

        internal static Context Context { get; private set; }

        public static void Init(Context context, Bundle bundle)
        {
            LinkAssemblies();

            Context = context;

            IsInitialized = true;
            OnInitialized?.Invoke(null, EventArgs.Empty);
        }

        public static bool SendBackPressed(Action backPressedHandler = null)
        {
            var popupNavigationInstance = PopupNavigation.Instance;

            if (popupNavigationInstance.PopupStack.Count > 0)
            {
                var lastPage = popupNavigationInstance.PopupStack.Last();

                var isPreventClose = lastPage.DisappearingTransactionTask != null || lastPage.SendBackButtonPressed();

                if (!isPreventClose)
                {
                    Device.InvokeOnMainThreadAsync(async () =>
                    {
                        await popupNavigationInstance.PopAsync();
                    });
                }

                return true;
            }

            backPressedHandler?.Invoke();

            return false;
        }

        private static void LinkAssemblies()
        {
            if (false.Equals(true))
            {
#pragma warning disable IDE0067 // Dispose objects before losing scope
                var i = new PopupPlatformDroid();
                var r = new PopupPageRenderer(null);
#pragma warning restore IDE0067 // Dispose objects before losing scope
            }
        }
    }
}
