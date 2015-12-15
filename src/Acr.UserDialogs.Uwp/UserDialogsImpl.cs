using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Coding4Fun.Toolkit.Controls;
using Splat;


namespace Acr.UserDialogs {

    public class UserDialogsImpl : AbstractUserDialogs {

        public override ActionSheetDialog ActionSheetBuilder() {
            return new ActionSheetDialogImpl();
        }


        public override AlertDialog AlertBuilder() {
            return new AlertDialogImpl();
        }


        public override ConfirmDialog ConfirmBuilder() {
            return new ConfirmDialogImpl();
        }


        public override LoginDialog LoginBuilder() {
            return new LoginDialogImpl();
        }


        public override ProgressDialog ProgressBuilder() {
            return null;
        }


        public override PromptDialog PromptBuilder() {
            return new PromptDialogImpl();
        }


        public override ToastDialog ToastBuilder() {
            return new ToastDialogImpl();
        }


        public override void ShowImage(IBitmap image, string message, int timeoutMillis) {
            //this.Show(null, message, ToastConfig.SuccessBackgroundColor, timeoutMillis);
        }


        public override void ShowError(string message, int timeoutMillis) {
            //this.Show(null, message, ToastConfig.ErrorBackgroundColor, timeoutMillis);
        }


        public override void ShowSuccess(string message, int timeoutMillis) {
            //this.Show(null, message, ToastConfig.SuccessBackgroundColor, timeoutMillis);
        }


        void Show(IBitmap image, string message, Color bgColor, int timeoutMillis) {
            //var cd = new ContentDialog {
            //    Background = new SolidColorBrush(bgColor.ToNative()),
            //    Content = new TextBlock { Text = message }
            //};
            //this.Dispatch(() => cd.ShowAsync());
            //Task.Delay(TimeSpan.FromMilliseconds(timeoutMillis))
            //    .ContinueWith(x => {
            //        try {
            //            this.Dispatch(() => cd.Hide());
            //        }
            //        catch { }
            //    });
        }


        //protected virtual void Dispatch(Action action) {
        //    CoreWindow
        //        .GetForCurrentThread()
        //        .Dispatcher
        //        .RunAsync(CoreDispatcherPriority.Normal, () => action());
        //}
    }
}