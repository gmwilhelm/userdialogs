using System;
using System.Threading;
using System.Threading.Tasks;
using UIKit;


namespace Acr.UserDialogs {

    public class ConfirmDialogImpl : ConfirmDialog {

        public override async Task<bool> Request(CancellationToken? cancelToken = null) {
            var tcs = new TaskCompletionSource<bool>();
            if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0)) {
                var alert = UIAlertController.Create(this.Title ?? String.Empty, this.Message, UIAlertControllerStyle.Alert);
                alert.AddAction(UIAlertAction.Create(this.OkText ?? DefaultOkText, UIAlertActionStyle.Default, x => tcs.TrySetResult(true)));
                alert.AddAction(UIAlertAction.Create(this.CancelText ?? DefaultCancelText, UIAlertActionStyle.Cancel, x => tcs.TrySetResult(false)));
                //this.Present(alert);
            }
            else {
                var dlg = new UIAlertView(this.Title ?? String.Empty, this.Message, null, this.CancelText, this.OkText);
                //dlg.Clicked += (s, e) => config.OnOk?.Invoke();
                //this.Present(dlg);
            }
            return true;
        }


        protected override void Dispose(bool disposing) {

        }
    }
}
/*
            if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0)) {
                var dlg = UIAlertController.Create(config.Title ?? String.Empty, config.Message, UIAlertControllerStyle.Alert);
                dlg.AddAction(UIAlertAction.Create(config.CancelText, UIAlertActionStyle.Cancel, x => config.OnConfirm(false)));
                dlg.AddAction(UIAlertAction.Create(config.OkText, UIAlertActionStyle.Default, x => config.OnConfirm(true)));
                this.Present(dlg);
            }
            else {
                var dlg = new UIAlertView(config.Title ?? String.Empty, config.Message, null, config.CancelText, config.OkText);
                dlg.Clicked += (s, e) => {
                    var ok = ((int)dlg.CancelButtonIndex != (int)e.ButtonIndex);
                    config.OnConfirm(ok);
                };
                this.Present(dlg);
            }
*/