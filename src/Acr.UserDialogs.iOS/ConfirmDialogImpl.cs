using System;
using System.Threading;
using System.Threading.Tasks;
using Acr.Support.iOS;
using UIKit;


namespace Acr.UserDialogs {

    public class ConfirmDialogImpl : ConfirmDialog {
        readonly AlertDialogManager<bool> manager = new AlertDialogManager<bool>();

        public override async Task<bool> Request(CancellationToken? cancelToken = null) {
            this.manager.AssertFree();

            if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0)) {
                var ctrl = UIAlertController.Create(this.Title ?? String.Empty, this.Message, UIAlertControllerStyle.Alert);
                this.manager.Alloc(ctrl);

                ctrl.AddAction(UIAlertAction.Create(this.OkText ?? DefaultOkText, UIAlertActionStyle.Default, x => this.manager.Tcs.TrySetResult(true)));
                ctrl.AddAction(UIAlertAction.Create(this.CancelText ?? DefaultCancelText, UIAlertActionStyle.Cancel, x => this.manager.Tcs.TrySetResult(false)));
                UIApplication.SharedApplication.Present(ctrl);
            }
            else {
                var view = new UIAlertView(this.Title ?? String.Empty, this.Message, null, this.CancelText, this.OkText);
                this.manager.Alloc(view);
                view.Clicked += (s, e) => {
                    var ok = (int)view.CancelButtonIndex != (int)e.ButtonIndex;
                    this.manager.Tcs.TrySetResult(ok);
                };
                UIApplication.SharedApplication.InvokeOnMainThread(view.Show);
            }
            var result = await this.manager.Tcs.Task;
            this.manager.Free();
            return result;
        }


        public override void Cancel() {
            base.Cancel();
            this.manager.Free();
        }
    }
}