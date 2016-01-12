using System;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Popups;


namespace Acr.UserDialogs {

    public class ConfirmDialogImpl : AbstractConfirmDialog {
        TaskCompletionSource<bool> tcs;
        IAsyncOperation<IUICommand> dialogCancel;


        public override void Cancel() {
            base.Cancel();
            this.dialogCancel?.Cancel();
            this.tcs?.TrySetCanceled();
        }


        public override Task<bool> Request(CancellationToken? cancelToken = null) {
            this.tcs = new TaskCompletionSource<bool>();
            cancelToken?.Register(this.Cancel);

            var dialog = new MessageDialog(this.Message, this.Title);
            dialog.Commands.Add(new UICommand(this.OkText, x => this.tcs.TrySetResult(true)));
            dialog.DefaultCommandIndex = 0;

            dialog.Commands.Add(new UICommand(this.CancelText, x => this.tcs.TrySetResult(false)));
            dialog.CancelCommandIndex = 1;
            this.Dispatch(() => this.dialogCancel = dialog.ShowAsync());

            return this.tcs.Task;
        }
    }
}