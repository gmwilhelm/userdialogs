using System;
using System.Threading;
using System.Threading.Tasks;
using Windows.UI.Popups;


namespace Acr.UserDialogs {

    public class AlertDialogImpl : AlertDialog {
        TaskCompletionSource<bool> tcs;


        public override void Show() {
            throw new NotImplementedException();
        }


        public override Task Request(CancellationToken? cancelToken = null) {
            this.tcs = new TaskCompletionSource<bool>();
            cancelToken?.Register(this.Cancel);

            var dialog = new MessageDialog(this.Message, this.Title);
            dialog.Commands.Add(new UICommand(this.OkText, x => this.tcs.TrySetResult(true)));
            //this.Dispatch(() => dialog.ShowAsync());

            return this.tcs.Task;
        }
    }
}