using System;


namespace Acr.UserDialogs {

    public class ToastDialogImpl : ToastDialog {

        public override void Show() {
            throw new NotImplementedException();
        }
    }
}
/*
            // TODO: backgroundcolor and image
            var resources = Application.Current.Resources;
            var textColor = new SolidColorBrush(cfg.TextColor.ToNative());
            var bgColor = cfg.BackgroundColor.ToNative();

            var wrapper = new StackPanel {
                HorizontalAlignment = HorizontalAlignment.Stretch,
                //Background = (Brush)resources["PhoneAccentBrush"],
                Background = new SolidColorBrush(bgColor),
                Width = Application.Current.Host.Content.ActualWidth
            };
            wrapper.Children.Add(new TextBlock {
                //Foreground = (Brush)resources["PhoneForegroundBrush"],
                Foreground = textColor,
                FontSize = (double)resources["PhoneFontSizeMedium"],
                Margin = new Thickness(24, 32, 24, 12),
                HorizontalAlignment = HorizontalAlignment.Center,
                Text = cfg.Title
            });

            if (!String.IsNullOrWhiteSpace(cfg.Description)) {
                wrapper.Children.Add(new TextBlock {
                    //Foreground = (Brush)resources["PhoneForegroundBrush"],
                    //FontSize = (double)resources["PhoneFontSizeMedium"],
                    Foreground = textColor,
                    FontSize = (double)resources["PhoneFontSizeSmall"],
                    Margin = new Thickness(24, 32, 24, 12),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Text = cfg.Title
                });
            }

            var popup = new Popup {
                Child = wrapper,
                HorizontalAlignment = HorizontalAlignment.Stretch
            };
            wrapper.Tap += (sender, args) => {
                SystemTray.BackgroundColor = (Color)resources["PhoneBackgroundColor"];
                popup.IsOpen = false;
                cfg.Action?.Invoke();
            };

            this.Dispatch(() => {
                //SystemTray.BackgroundColor = (Color)resources["PhoneAccentColor"];
                SystemTray.BackgroundColor = bgColor;
                popup.IsOpen = true;
            });
            Task.Delay(cfg.Duration)
                .ContinueWith(x => this.Dispatch(() => {
                    SystemTray.BackgroundColor = (Color)resources["PhoneBackgroundColor"];
                    popup.IsOpen = false;
                }));
*/