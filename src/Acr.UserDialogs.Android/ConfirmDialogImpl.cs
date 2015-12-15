using System;
using System.Threading;
using System.Threading.Tasks;


namespace Acr.UserDialogs {

    public class ConfirmDialogImpl : ConfirmDialog {

        public override Task<bool> Request(CancellationToken? cancelToken = null) {
            throw new NotImplementedException();
        }
    }
}
/*
            Utils.RequestMainThread(() =>

/* Unmerged change from project 'Acr.UserDialogs.Android.AppCompat'
Before:
                new AlertDialog
After:
                new Android.Support.V7.App.AlertDialog

                new Android.App.AlertDialog
                    .Builder(this.GetTopActivity())
                    .SetCancelable(false)
                    .SetMessage(config.Message)
                    .SetTitle(config.Title)
                    .SetPositiveButton(config.OkText, (s, a) => config.OnConfirm(true))
                    .SetNegativeButton(config.CancelText, (s, a) => config.OnConfirm(false))
                    .ShowExt()
            );
*/