using System;


namespace Acr.UserDialogs {

    public class ToastDialogImpl : ToastDialog {

        public override void Show() {
            throw new NotImplementedException();
        }
    }
}
/*
            var toast = new ToastPrompt {
                Background = new SolidColorBrush(config.BackgroundColor.ToNative()),
                Foreground = new SolidColorBrush(config.TextColor.ToNative()),
                Title = config.Title,
                Message = config.Description,
                ImageSource = config.Icon?.ToNative(),
                Stretch = Stretch.Fill,
                MillisecondsUntilHidden = Convert.ToInt32(config.Duration.TotalMilliseconds)
            };
            //toast.Completed += (sender, args) => {
            //    if (args.PopUpResult == PopUpResult.Ok)
            //        config.Action?.Invoke();
            //};
            this.Dispatch(toast.Show);
*/