using System;
using Windows.UI.Core;


namespace Acr.UserDialogs {

    public static class Extensions {

        public static void Dispatch(this AbstractDialog dialog, Action action) {
            CoreWindow
                .GetForCurrentThread()
                .Dispatcher
                .RunAsync(CoreDispatcherPriority.Normal, () => action());
        }
    }
}
