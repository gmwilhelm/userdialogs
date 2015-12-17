using System;
using Android.App;
using AndroidHUD;


namespace Acr.UserDialogs {

    public class ToastDialogImpl : ToastDialog {
        readonly Activity activity;


        public ToastDialogImpl(Activity activity) {
            this.activity = activity;
        }


        public override void Cancel() {
            base.Cancel();
            AndHUD.Shared.Dismiss(this.activity);
        }


        public override void Show() {
            //Utils.RequestMainThread(() => {
            var txt = this.Title;
            if (!String.IsNullOrWhiteSpace(this.Description))
                txt += Environment.NewLine + this.Description;

            AndHUD.Shared.ShowToast(
                this.activity,
                txt,
                AndroidHUD.MaskType.Black,
                this.Duration,
                false,
                () => {
                    AndHUD.Shared.Dismiss();
                    this.Action?.Invoke();
                }
            );
        }
    }
}