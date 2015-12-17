using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Phone.Controls;


namespace Acr.UserDialogs {

    public class AlertDialogImpl : AlertDialog {
        TaskCompletionSource<bool> tcs;


        public override void Show() {
            throw new NotImplementedException();
        }


        public override Task Request(CancellationToken? cancelToken = null) {
            this.tcs = new TaskCompletionSource<bool>();
            //this.Dispatch(() => {
                var alert = new CustomMessageBox {
                    Caption = this.Title,
                    Message = this.Message,
                    LeftButtonContent = this.OkText,
                    IsRightButtonEnabled = false
                };
                alert.Dismissed += (sender, args) => this.tcs.TrySetResult(true);

                alert.Show();
            //});
            return this.tcs.Task;
        }
    }
}
