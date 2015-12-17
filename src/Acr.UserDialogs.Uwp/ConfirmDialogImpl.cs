using System;
using System.Threading;
using System.Threading.Tasks;
using Windows.UI.Popups;


namespace Acr.UserDialogs {

    public class ConfirmDialogImpl : ConfirmDialog {
        TaskCompletionSource<bool> tcs;


        public override Task<bool> Request(CancellationToken? cancelToken = null) {
            var dialog = new MessageDialog(this.Message, this.Title);
            dialog.Commands.Add(new UICommand(this.OkText, x => this.tcs.TrySetResult(true)));
            dialog.DefaultCommandIndex = 0;

            dialog.Commands.Add(new UICommand(this.CancelText, x => this.tcs.TrySetResult(false)));
            dialog.CancelCommandIndex = 1;
            //this.Dispatch(() => dialog.ShowAsync());

            return null;
        }
    }
}