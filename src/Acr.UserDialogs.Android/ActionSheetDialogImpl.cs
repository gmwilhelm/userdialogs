using System;
using System.Linq;
using Android.App;
#if APPCOMPAT
using AD = Android.Support.V7.App.AlertDialog;
#else
using AD = Android.App.AlertDialog;
#endif


namespace Acr.UserDialogs {

    public class ActionSheetDialogImpl : ActionSheetDialog {
        readonly Activity activity;
        AD dialog;


        public ActionSheetDialogImpl(Activity activity) {
            this.activity = activity;
        }


        public override void Show() {
            var dlg = new AD
                .Builder(this.activity)
                .SetCancelable(false)
                .SetTitle(this.Title);

            if (this.ItemIcon != null || this.Options.Any(x => x.ItemIcon != null)) {
                var adapter = new ActionSheetListAdapter(this.activity, Android.Resource.Layout.SelectDialogItem, Android.Resource.Id.Text1, this);
                dlg.SetAdapter(adapter, (s, a) => this.Options[a.Which].Action?.Invoke());
            }
            else {
                var array = this
                    .Options
                    .Select(x => x.Text)
                    .ToArray();

                dlg.SetItems(array, (s, args) => this.Options[args.Which].Action?.Invoke());
            }

            if (this.DestructiveOption != null)
                dlg.SetNegativeButton(this.DestructiveOption.Text, (s, a) => this.DestructiveOption.Action?.Invoke());

            if (this.CancelOption != null)
                dlg.SetNeutralButton(this.CancelOption.Text, (s, a) => this.CancelOption.Action?.Invoke());

            Acr.Support.Android.Extensions.RequestMainThread(() => dlg.ShowExt());
        }


        public override void Cancel() {
            base.Cancel();
            this.dialog?.Dispose();
        }
    }
}