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

    public class AlertDialogImpl : AlertDialog {
        readonly Activity activity;


        public AlertDialogImpl(Activity topActivity) {
            this.activity = topActivity;
        }


        public override void Show() {
            throw new NotImplementedException();
        }


        public override Task Request(CancellationToken? cancelToken = null) {
            throw new NotImplementedException();
        }
    }
}