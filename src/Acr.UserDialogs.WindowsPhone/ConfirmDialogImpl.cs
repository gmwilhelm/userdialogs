using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Phone.Controls;


namespace Acr.UserDialogs {

    public class ConfirmDialogImpl : ConfirmDialog {
        readonly TaskCompletionSource<bool> tcs;
        CustomMessageBox messageBox;


        public override Task<bool> Request(CancellationToken? cancelToken = null) {
            this.messageBox = new CustomMessageBox {
                Caption = this.Title,
                Message = this.Message,
                LeftButtonContent = this.OkText,
                RightButtonContent = this.CancelText
            };
            this.messageBox.Dismissed += (sender, args) => this.tcs.TrySetResult(args.Result == CustomMessageBoxResult.LeftButton);
            //this.Dispatch(confirm.Show);
            return this.tcs.Task;
        }
    }
}