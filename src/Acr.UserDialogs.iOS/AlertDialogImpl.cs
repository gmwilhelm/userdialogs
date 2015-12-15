﻿using System;
using System.Threading;
using System.Threading.Tasks;
using UIKit;


namespace Acr.UserDialogs {

    public class AlertDialogImpl : AlertDialog {
        readonly AlertDialogManager<bool> manager = new AlertDialogManager<bool>();


        public override void Cancel() {
            base.Cancel();
            this.manager.Free();
        }


        public override void Show() {
            this.Request();
        }


        public override async Task Request(CancellationToken? cancelToken = null) {
            this.manager.AssertFree();

            if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0)) {
                var ctrl = UIAlertController.Create(this.Title ?? String.Empty, this.Message, UIAlertControllerStyle.Alert);
                this.manager.Alloc(ctrl);

                ctrl.AddAction(UIAlertAction.Create(this.OkText ?? DefaultOkText, UIAlertActionStyle.Default, x => this.manager.Tcs.TrySetResult(true)));
                //this.Present(alert);
            }
            else {
                var view = new UIAlertView(this.Title ?? String.Empty, this.Message, null, null, this.OkText);
                this.manager.Alloc(view);

                view.Clicked += (s, e) => this.manager.Tcs.TrySetResult(true);
                //this.Present(dlg);
            }
            await this.manager.Tcs.Task;
            this.manager.Free();
        }
    }
}