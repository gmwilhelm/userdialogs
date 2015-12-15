using System;
using System.Threading;
using System.Threading.Tasks;
using UIKit;


namespace Acr.UserDialogs {

    public class AlertDialogImpl : AlertDialog {

        public override void Show() {
            throw new NotImplementedException();
        }


        public override async Task Request(CancellationToken? cancelToken = null) {
            var tcs = new TaskCompletionSource<bool>();
            if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0)) {
                var alert = UIAlertController.Create(this.Title ?? String.Empty, this.Message, UIAlertControllerStyle.Alert);
                alert.AddAction(UIAlertAction.Create(this.OkText ?? DefaultOkText, UIAlertActionStyle.Default, x => tcs.TrySetResult(true)));
                //this.Present(alert);
            }
            else {
                var dlg = new UIAlertView(this.Title ?? String.Empty, this.Message, null, null, this.OkText);
                //dlg.Clicked += (s, e) => config.OnOk?.Invoke();
                //this.Present(dlg);
            }
        }


        protected override void Dispose(bool disposing) {

        }
    }
}