using System;
using Android.App;
using Android.Graphics.Drawables;
using Android.Support.Design.Widget;
using Android.Text;
using Android.Views;
using Android.Widget;
using Splat;


namespace Acr.UserDialogs {

    public class ToastDialogImpl : ToastDialog {
        readonly Activity activity;


        public ToastDialogImpl(Activity activity) {
            this.activity = activity;
        }


        public override void Show() {
            var view = this.activity.Window.DecorView.RootView.FindViewById(Android.Resource.Id.Content);

            var text = $"<b>{this.Title}</b>";
            if (!String.IsNullOrWhiteSpace(this.Description))
                text += $"\n<br /><i>{this.Description}</i>";

            var snackBar = Snackbar.Make(view, text, (int)this.Duration.TotalMilliseconds);
            snackBar.View.Background = new ColorDrawable(this.BackgroundColor.ToNative());
            var txt = this.FindTextView(snackBar);
            txt.SetTextColor(this.TextColor.ToNative());
            txt.TextFormatted = Html.FromHtml(text);

            snackBar.View.Click += (sender, args) => {
                snackBar.Dismiss();
                this.Action?.Invoke();
            };
            Acr.Support.Android.Extensions.RequestMainThread(snackBar.Show);
        }


        protected virtual TextView FindTextView(Snackbar bar) {
            var group = (ViewGroup)bar.View;
            for (var i = 0; i < group.ChildCount; i++) {
                var txt = group.GetChildAt(i) as TextView;
                if (txt != null)
                    return txt;
            }
            throw new Exception("No textview found on snackbar");
        }
    }
}