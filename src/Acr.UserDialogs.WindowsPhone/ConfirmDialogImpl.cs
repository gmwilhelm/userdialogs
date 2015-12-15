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
            var confirm = new CustomMessageBox {
                Caption = config.Title,
                Message = config.Message,
                LeftButtonContent = config.OkText,
                RightButtonContent = config.CancelText
            };
            confirm.Dismissed += (sender, args) => config.OnConfirm(args.Result == CustomMessageBoxResult.LeftButton);
            this.Dispatch(confirm.Show);
*/