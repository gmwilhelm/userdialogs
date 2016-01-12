using System;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
#if APPCOMPAT
using AD = Android.Support.V7.App.AlertDialog;
#else
using AD = Android.App.AlertDialog;
#endif


namespace Acr.UserDialogs {

    public class AlertDialogImpl : AbstractAlertDialog {
        readonly Activity activity;
        TaskCompletionSource<bool> tcs;
        AD dialog;


        public AlertDialogImpl(Activity topActivity) {
            this.activity = topActivity;
        }


        public override void Show() {
            this.Request();
        }


        public override Task Request(CancellationToken? cancelToken = null) {
            cancelToken?.Register(this.Cancel);

            this.tcs = new TaskCompletionSource<bool>();
            Acr.Support.Android.Extensions.RequestMainThread(() =>
                this.dialog = new AD
                    .Builder(this.activity)
                    .SetCancelable(false)
                    .SetMessage(this.Message)
                    .SetTitle(this.Title)
                    .SetPositiveButton(this.OkText, (s, a) => this.tcs.TrySetResult(true))
                    .ShowExt()
            );
            return this.tcs.Task;
        }


        public override void Cancel() {
            base.Cancel();
            this.tcs?.TrySetCanceled();
            this.dialog?.Dispose();
        }
    }
}