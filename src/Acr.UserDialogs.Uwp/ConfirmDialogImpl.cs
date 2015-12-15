using System;
using System.Threading;
using System.Threading.Tasks;


namespace Acr.UserDialogs {

    public class ConfirmDialogImpl : ConfirmDialog {

        public override Task<bool> Request(CancellationToken? cancelToken = null) {
            throw new NotImplementedException();
        }
    }
}
/*
            var dialog = new MessageDialog(config.Message, config.Title);
            dialog.Commands.Add(new UICommand(config.OkText, x => config.OnConfirm(true)));
            dialog.DefaultCommandIndex = 0;

            dialog.Commands.Add(new UICommand(config.CancelText, x => config.OnConfirm(false)));
            dialog.CancelCommandIndex = 1;
            this.Dispatch(() => dialog.ShowAsync());
*/