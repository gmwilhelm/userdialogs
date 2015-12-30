using System;
using BigTed;
using UIKit;


namespace Acr.UserDialogs {

    public class ProgressDialogImpl : ProgressDialog {
        // if title or percent complete changes we need to update

        //string title;
        //public virtual string Title {
        //    get { return this.title; }
        //    set {
        //        if (this.title == value)
        //            return;

        //        this.title = value;
        //        this.Refresh();
        //    }
        //}


        //int percentComplete;
        //public virtual int PercentComplete {
        //    get { return this.percentComplete; }
        //    set {
        //        if (this.percentComplete == value)
        //            return;

        //        if (value > 100)
        //            this.percentComplete = 100;
        //        else if (value < 0)
        //            this.percentComplete = 0;
        //        else
        //            this.percentComplete = value;
        //        this.Refresh();
        //    }
        //}


        public override void Cancel() {
            base.Cancel();
            UIApplication.SharedApplication.InvokeOnMainThread(BTProgressHUD.Dismiss);
        }


        protected virtual void Refresh() {
            if (!this.IsShowing)
                return;

            var txt = this.Title;
            float p = -1;
            if (this.IsDeterministic) {
                p = (float)this.PercentComplete / 100;
                if (!String.IsNullOrWhiteSpace(txt))
                    txt += "... ";

                txt += this.PercentComplete + "%";
            }

            UIApplication.SharedApplication.InvokeOnMainThread(() => {
                if (this.CancelOption == null) {
                    BTProgressHUD.Show(
                        this.Title,
                        p,
                        this.MaskType.ToNative()
                    );
                }
                else {
                    BTProgressHUD.Show(
                        this.CancelOption.Text,
                        this.CancelOption.Action,
                        txt,
                        p,
                        this.MaskType.ToNative()
                    );
                }
            });
        }
    }
}