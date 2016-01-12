using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Phone.Controls;


namespace Acr.UserDialogs {

    public class ConfirmDialogImpl : AbstractConfirmDialog {
        TaskCompletionSource<bool> tcs;
        CustomMessageBox messageBox;


        public override void Cancel() {
            base.Cancel();
            this.tcs?.TrySetCanceled();
            this.messageBox.Dismiss();
        }


        public override Task<bool> Request(CancellationToken? cancelToken = null) {
            cancelToken?.Register(this.Cancel);
            this.tcs = new TaskCompletionSource<bool>();

            this.messageBox = new CustomMessageBox {
                Caption = this.Title,
                Message = this.Message,
                LeftButtonContent = this.OkText,
                RightButtonContent = this.CancelText
            };
            this.messageBox.Dismissed += (sender, args) => this.tcs.TrySetResult(args.Result == CustomMessageBoxResult.LeftButton);
            Deployment.Current.Dispatcher.BeginInvoke(this.messageBox.Show);
            return this.tcs.Task;
        }
    }
}