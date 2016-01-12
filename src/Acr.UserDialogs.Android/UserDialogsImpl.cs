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


        public override IActionSheetDialog ActionSheetBuilder() {
            return new ActionSheetDialogImpl(this.GetTopActivity());
        }


        public override IAlertDialog AlertBuilder() {
            return new AlertDialogImpl(this.GetTopActivity());
        }


        public override IConfirmDialog ConfirmBuilder() {
            return new ConfirmDialogImpl(this.GetTopActivity());
        }


        public override ILoginDialog LoginBuilder() {
            return new LoginDialogImpl(this.GetTopActivity());
        }


        public override IProgressDialog ProgressBuilder() {
            return new ProgressDialogImpl(this.GetTopActivity());
        }


        public override IPromptDialog PromptBuilder() {
            return new PromptDialogImpl(this.GetTopActivity());
        }


        public override IToastDialog ToastBuilder() {
            return new ToastDialogImpl(this.GetTopActivity());
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