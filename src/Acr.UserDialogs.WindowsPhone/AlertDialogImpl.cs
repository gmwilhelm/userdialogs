using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Phone.Controls;


namespace Acr.UserDialogs {

    public class AlertDialogImpl : AlertDialog {
        TaskCompletionSource<bool> tcs;
        CustomMessageBox alert;


        public override void Cancel() {
            base.Cancel();
            this.tcs?.TrySetCanceled();
            this.alert?.Dismiss();
        }


        public override void Show() {
            this.Request();
        }


        public override Task Request(CancellationToken? cancelToken = null) {
            cancelToken?.Register(this.Cancel);
            this.tcs = new TaskCompletionSource<bool>();

            this.alert = new CustomMessageBox {
                Caption = this.Title,
                Message = this.Message,
                LeftButtonContent = this.OkText,
                IsRightButtonEnabled = false
            };
            this.alert.Dismissed += (sender, args) => this.tcs.TrySetResult(true);

            Deployment.Current.Dispatcher.BeginInvoke(this.alert.Show);
            return this.tcs.Task;
        }
    }
}
