using System;
using Windows.UI.Xaml.Media;
using Coding4Fun.Toolkit.Controls;
using Splat;


namespace Acr.UserDialogs {

    public class ToastDialogImpl : AbstractToastDialog {
        ToastPrompt toast;


        public override void Cancel() {
            base.Cancel();
            this.toast?.Hide();
            this.toast?.Dispose();
        }


        public override void Show() {
            this.Cancel();

            this.toast = new ToastPrompt {
                Background = new SolidColorBrush(this.BackgroundColor.ToNative()),
                Foreground = new SolidColorBrush(this.TextColor.ToNative()),
                Title = this.Title,
                Message = this.Description,
                ImageSource = this.Icon?.ToNative(),
                Stretch = Stretch.Fill,
                MillisecondsUntilHidden = Convert.ToInt32(this.Duration.TotalMilliseconds)
            };
            this.toast.Completed += (sender, args) => {
                if (args.PopUpResult == PopUpResult.Ok)
                    this.Action?.Invoke();
            };
            this.Dispatch(this.toast.Show);
        }
    }
}