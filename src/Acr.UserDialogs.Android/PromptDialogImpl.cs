using System;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Text;
using Android.Text.Method;
using Android.Widget;
#if APPCOMPAT
using AD = Android.Support.V7.App.AlertDialog;
#else
using AD = Android.App.AlertDialog;
#endif


namespace Acr.UserDialogs {

    public class PromptDialogImpl : PromptDialog {
        readonly Activity activity;
        TaskCompletionSource<PromptResult> tcs;
        AD dialog;


        public PromptDialogImpl(Activity activity) {
            this.activity = activity;
        }


        public override Task<PromptResult> Request(CancellationToken? cancelToken) {
            cancelToken?.Register(this.Cancel);
            this.tcs = new TaskCompletionSource<PromptResult>();

            var txt = new EditText(this.activity) {
                Hint = this.PlaceholderText
            };
            txt.SetInputType(this.InputType);

			if (this.Text != null)
				txt.Text = this.Text;

            var builder = new AD
                .Builder(this.activity)
                .SetCancelable(false)
                .SetMessage(this.Message)
                .SetTitle(this.Title)
                .SetView(txt)
                .SetPositiveButton(this.OkText, (s, a) =>
                    this.tcs.TrySetResult(new PromptResult(true, txt.Text.Trim())
				));

			if (this.IsCancellable)
				builder.SetNegativeButton(this.CancelText, (s, a) =>
                    this.tcs.TrySetResult(new PromptResult(false, txt.Text.Trim())
				));

            Acr.Support.Android.Extensions.RequestMainThread(() =>
			    this.dialog = builder.ShowExt()
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