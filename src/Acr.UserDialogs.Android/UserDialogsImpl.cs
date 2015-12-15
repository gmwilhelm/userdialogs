using System;
using Android.App;
using AndroidHUD;
using Splat;
using Utils = Acr.Support.Android.Extensions;


namespace Acr.UserDialogs {

    public class UserDialogsImpl : AbstractUserDialogs {
        protected Func<Activity> GetTopActivity { get; set; }


        public UserDialogsImpl(Func<Activity> getTopActivity) {
            this.GetTopActivity = getTopActivity;
        }


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
            return new ProgressDialogImpl();
        }


        public override PromptDialog PromptBuilder() {
            return new PromptDialogImpl();
        }


        public override ToastDialog ToastBuilder() {
            return new ToastDialogImpl();
        }


        public override void ShowImage(IBitmap image, string message, int timeoutMillis) {
            Utils.RequestMainThread(() =>
                AndHUD.Shared.ShowImage(this.GetTopActivity(), image.ToNative(), message, AndroidHUD.MaskType.Black, TimeSpan.FromMilliseconds(timeoutMillis))
            );
        }


        public override void ShowSuccess(string message, int timeoutMillis) {
            Utils.RequestMainThread(() =>
                AndHUD.Shared.ShowSuccess(this.GetTopActivity(), message, timeout: TimeSpan.FromMilliseconds(timeoutMillis))
            );
        }


        public override void ShowError(string message, int timeoutMillis) {
            Utils.RequestMainThread(() =>
                AndHUD.Shared.ShowError(this.GetTopActivity(), message, timeout: TimeSpan.FromMilliseconds(timeoutMillis))
            );
        }
    }
}