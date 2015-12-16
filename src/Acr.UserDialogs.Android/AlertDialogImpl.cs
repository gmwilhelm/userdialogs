using System;
using System.Threading;
using System.Threading.Tasks;
using Android.App;


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