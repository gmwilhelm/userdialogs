using System;
using System.Threading;
using System.Threading.Tasks;


namespace Acr.UserDialogs {

    public class AlertDialogImpl : AlertDialog {

        public override void Show() {
            throw new NotImplementedException();
        }


        public override Task Request(CancellationToken? cancelToken = null) {
            throw new NotImplementedException();
        }
    }
}
/*
            this.Dispatch(() => {
                var alert = new CustomMessageBox {
                    Caption = config.Title,
                    Message = config.Message,
                    LeftButtonContent = config.OkText,
                    IsRightButtonEnabled = false
                };
                alert.Dismissed += (sender, args) => config.OnOk?.Invoke();

                alert.Show();
            });
*/