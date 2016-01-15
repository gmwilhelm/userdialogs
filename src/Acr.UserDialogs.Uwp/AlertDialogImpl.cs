using System;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Popups;


namespace Acr.UserDialogs {

    public class AlertDialogImpl : AbstractAlertDialog {
        TaskCompletionSource<bool> tcs;
        IAsyncOperation<IUICommand> dialogCancel;


        public override void Cancel() {
            base.Cancel();
            this.dialogCancel?.Cancel();
            this.tcs?.TrySetCanceled();
        }


        public override void Show() {
            this.Request();
        }


        public override Task Request(CancellationToken? cancelToken = null) {
            this.tcs = new TaskCompletionSource<bool>();
            cancelToken?.Register(this.Cancel);

            var dialog = new MessageDialog(this.Message, this.Title ?? String.Empty);
            dialog.Commands.Add(new UICommand(this.OkText, x => this.tcs.TrySetResult(true)));
            this.Dispatch(() => this.dialogCancel = dialog.ShowAsync());

            return this.tcs.Task;
        }
    }
}