using System;
using System.Drawing;
using Splat;


namespace Acr.UserDialogs {

    public class UserDialogsImpl : AbstractUserDialogs {

        public override IActionSheetDialog ActionSheetBuilder() {
            return new ActionSheetDialogImpl();
        }


        public override IAlertDialog AlertBuilder() {
            return new AlertDialogImpl();
        }


        public override IConfirmDialog ConfirmBuilder() {
            return new ConfirmDialogImpl();
        }


        public override ILoginDialog LoginBuilder() {
            return new LoginDialogImpl();
        }


        public override IProgressDialog ProgressBuilder() {
            return new ProgressDialogImpl();
        }


        public override IPromptDialog PromptBuilder() {
            return new PromptDialogImpl();
        }


        public override IToastDialog ToastBuilder() {
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
    }
}