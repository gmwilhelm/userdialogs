using System;
using System.Threading;
using System.Threading.Tasks;
using UIKit;


namespace Acr.UserDialogs {

    public class ConfirmDialogImpl : ConfirmDialog {
        TaskCompletionSource<bool> tcs;
        UIAlertController alertCtrl;
        UIAlertView alertView;


        public override async Task<bool> Request(CancellationToken? cancelToken = null) {
            this.tcs = new TaskCompletionSource<bool>();

            if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0)) {
                this.alertCtrl = UIAlertController.Create(this.Title ?? String.Empty, this.Message, UIAlertControllerStyle.Alert);
                this.alertCtrl.AddAction(UIAlertAction.Create(this.OkText ?? DefaultOkText, UIAlertActionStyle.Default, x => this.tcs.TrySetResult(true)));
                this.alertCtrl.AddAction(UIAlertAction.Create(this.CancelText ?? DefaultCancelText, UIAlertActionStyle.Cancel, x => this.tcs.TrySetResult(false)));
                //this.Present(alert);
            }
            else {
                this.alertView = new UIAlertView(this.Title ?? String.Empty, this.Message, null, this.CancelText, this.OkText);
                this.alertView.Clicked += (s, e) => {
                    var ok = (int)this.alertView.CancelButtonIndex != (int)e.ButtonIndex;
                    this.tcs.TrySetResult(ok);
                };
                //this.Present(dlg);
            }
            return await this.tcs.Task;
        }


        protected override void Dispose(bool disposing) {
            this.Cancel();
        }
    }
}