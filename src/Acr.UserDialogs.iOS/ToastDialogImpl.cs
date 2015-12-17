using System;
using MessageBar;
using UIKit;


namespace Acr.UserDialogs {

    public class ToastDialogImpl : ToastDialog {
        //this.toastTimer = new Timer();
        //this.toastTimer.Elapsed += (sender, args) => {
        //    this.toastTimer.Stop();
        //    UIApplication.SharedApplication.InvokeOnMainThread(MessageBarManager.SharedInstance.HideAll);
        //};


        public override void Cancel() {
            base.Cancel();
            UIApplication.SharedApplication.InvokeOnMainThread(MessageBarManager.SharedInstance.HideAll);
        }


        public override void Show() {
            UIApplication.SharedApplication.InvokeOnMainThread(() => {
                //MessageBarManager.SharedInstance.ShowAtTheBottom = ShowToastOnBottom;
                MessageBarManager.SharedInstance.HideAll();
                MessageBarManager.SharedInstance.StyleSheet = new AcrMessageBarStyleSheet(this);
                MessageBarManager.SharedInstance.ShowMessage(this.Title, this.Description ?? String.Empty, MessageType.Success, null, () => this.Action?.Invoke());

                //this.toastTimer.Stop();
                //this.toastTimer.Interval = cfg.Duration.TotalMilliseconds;
                //this.toastTimer.Start();
            });
        }
    }
}