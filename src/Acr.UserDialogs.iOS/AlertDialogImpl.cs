using System;
using System.Threading;
using System.Threading.Tasks;
using UIKit;


namespace Acr.UserDialogs {

    public class AlertDialogImpl : AlertDialog {

        public override async Task<bool> Request(CancellationToken? cancelToken = null) {
            if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0)) {
                var alert = UIAlertController.Create(this.Title ?? String.Empty, this.Message, UIAlertControllerStyle.Alert);
                //alert.AddAction(UIAlertAction.Create(config.OkText, UIAlertActionStyle.Default, x => config.OnOk?.Invoke()));
                //this.Present(alert);
            }
            else {
                var dlg = new UIAlertView(this.Title ?? String.Empty, this.Message, null, null, this.OkText);
                //dlg.Clicked += (s, e) => config.OnOk?.Invoke();
                //this.Present(dlg);
            }
            return true;
        }
    }
}
