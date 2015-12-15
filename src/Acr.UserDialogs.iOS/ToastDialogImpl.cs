using System;


namespace Acr.UserDialogs {

    public class ToastDialogImpl : ToastDialog {

        public override void Show() {
            throw new NotImplementedException();
        }
    }
}
/*
            UIApplication.SharedApplication.InvokeOnMainThread(() => {
                MessageBarManager.SharedInstance.ShowAtTheBottom = ShowToastOnBottom;
                MessageBarManager.SharedInstance.HideAll();
                MessageBarManager.SharedInstance.StyleSheet = new AcrMessageBarStyleSheet(cfg);
                MessageBarManager.SharedInstance.ShowMessage(cfg.Title, cfg.Description ?? String.Empty, MessageType.Success, null, () => cfg.Action?.Invoke());

                this.toastTimer.Stop();
                this.toastTimer.Interval = cfg.Duration.TotalMilliseconds;
                this.toastTimer.Start();
            });


                this.toastTimer = new Timer();
            this.toastTimer.Elapsed += (sender, args) => {
                this.toastTimer.Stop();
                UIApplication.SharedApplication.InvokeOnMainThread(MessageBarManager.SharedInstance.HideAll);
            };
*/