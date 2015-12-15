using System;


namespace Acr.UserDialogs {

    public class ToastDialogImpl : ToastDialog {

        public override void Show() {
            throw new NotImplementedException();
        }
    }
}
/*
#if APPCOMPAT

        public override void Toast(ToastConfig cfg) {
            var top = this.GetTopActivity();
            //var view = top.Window.DecorView.RootView;
            var view = top.Window.DecorView.RootView.FindViewById(Android.Resource.Id.Content);

            var text = $"<b>{cfg.Title}</b>";
            if (!String.IsNullOrWhiteSpace(cfg.Description))
                text += $"\n<br /><i>{cfg.Description}</i>";

            var snackBar = Snackbar.Make(view, text, (int)cfg.Duration.TotalMilliseconds);
            snackBar.View.Background = new ColorDrawable(cfg.BackgroundColor.ToNative());
            var txt = FindTextView(snackBar);
            txt.SetTextColor(cfg.TextColor.ToNative());
            txt.TextFormatted = Html.FromHtml(text);

            snackBar.View.Click += (sender, args) => {
                snackBar.Dismiss();
                cfg.Action?.Invoke();
            };
            Utils.RequestMainThread(snackBar.Show);
        }


        protected static TextView FindTextView(Snackbar bar) {
            var group = (ViewGroup)bar.View;
            for (var i = 0; i < group.ChildCount; i++) {
                var txt = group.GetChildAt(i) as TextView;
                if (txt != null)
                    return txt;
            }
            throw new Exception("No textview found on snackbar");
        }
#else
        public override void Toast(ToastConfig cfg) {
            Utils.RequestMainThread(() => {
				var top = this.GetTopActivity();
                var txt = cfg.Title;
                if (!String.IsNullOrWhiteSpace(cfg.Description))
                    txt += Environment.NewLine + cfg.Description;

                AndHUD.Shared.ShowToast(
                    top,
                    txt,
					AndroidHUD.MaskType.Black,
                    cfg.Duration,
                    false,
					() => {
						AndHUD.Shared.Dismiss();
                        cfg.Action?.Invoke();
					}
                );
            });
        }
#endif
#
*/