using System;
using System.Timers;
using MessageBar;
using UIKit;


namespace Acr.UserDialogs {

    public class ToastDialogImpl : AbstractToastDialog {
        static readonly Timer timer = new Timer();


        static ToastDialogImpl() {
            timer.Elapsed += (sender, args) => {
                timer.Stop();
                UIApplication.SharedApplication.InvokeOnMainThread(MessageBarManager.SharedInstance.HideAll);
            };
        }


        public override void Cancel() {
            base.Cancel();
            UIApplication.SharedApplication.InvokeOnMainThread(MessageBarManager.SharedInstance.HideAll);
        }


        public override void Show() {
            UIApplication.SharedApplication.InvokeOnMainThread(() => {
                MessageBarManager.SharedInstance.ShowAtTheBottom = this.Position == ToastPosition.Bottom;
                MessageBarManager.SharedInstance.HideAll();
                MessageBarManager.SharedInstance.StyleSheet = new AcrMessageBarStyleSheet(this);
                MessageBarManager.SharedInstance.ShowMessage(
                    this.Title,
                    this.Description ?? String.Empty,
                    MessageType.Success,
                    null,
                    () => this.Action?.Invoke()
                );

                timer.Stop();
                timer.Interval = this.Duration.TotalMilliseconds;
                timer.Start();
            });
        }
    }
}