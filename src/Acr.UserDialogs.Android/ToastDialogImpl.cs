using System;
using Android.App;
using AndroidHUD;


namespace Acr.UserDialogs {

    public class ToastDialogImpl : ToastDialog {
        readonly Activity activity;


        public ToastDialogImpl(Activity activity) {
            this.activity = activity;
        }


        public override void Show() {
    //        Utils.RequestMainThread(() => {
				//var top = this.GetTopActivity();
    //            var txt = cfg.Title;
    //            if (!String.IsNullOrWhiteSpace(cfg.Description))
    //                txt += Environment.NewLine + cfg.Description;

    //            AndHUD.Shared.ShowToast(
    //                top,
    //                txt,
				//	AndroidHUD.MaskType.Black,
    //                cfg.Duration,
    //                false,
				//	() => {
				//		AndHUD.Shared.Dismiss();
    //                    cfg.Action?.Invoke();
				//	}
    //            );
    //        });
        }
    }
}