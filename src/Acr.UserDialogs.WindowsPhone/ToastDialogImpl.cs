using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using Microsoft.Phone.Shell;
using Splat;


namespace Acr.UserDialogs {

    public class ToastDialogImpl : AbstractToastDialog {
        Popup popup;


        public override void Cancel() {
            base.Cancel();
            Deployment.Current.Dispatcher.BeginInvoke(() => {
                SystemTray.BackgroundColor = (Color)Application.Current.Resources["PhoneBackgroundColor"];
                popup.IsOpen = false;
            });
        }


        public override void Show() {
            // TODO: backgroundcolor and image
            var resources = Application.Current.Resources;
            var textColor = new SolidColorBrush(this.TextColor.ToNative());
            var bgColor = this.BackgroundColor.ToNative();

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
                Text = this.Title
            });

            if (!String.IsNullOrWhiteSpace(this.Description)) {
                wrapper.Children.Add(new TextBlock {
                    //Foreground = (Brush)resources["PhoneForegroundBrush"],
                    //FontSize = (double)resources["PhoneFontSizeMedium"],
                    Foreground = textColor,
                    FontSize = (double)resources["PhoneFontSizeSmall"],
                    Margin = new Thickness(24, 32, 24, 12),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Text = this.Title
                });
            }

            this.popup = new Popup {
                Child = wrapper,
                HorizontalAlignment = HorizontalAlignment.Stretch
            };
            wrapper.Tap += (sender, args) => {
                SystemTray.BackgroundColor = (Color)resources["PhoneBackgroundColor"];
                this.popup.IsOpen = false;
                this.Action?.Invoke();
            };

            Deployment.Current.Dispatcher.BeginInvoke(() => {
                SystemTray.BackgroundColor = bgColor;
                this.popup.IsOpen = true;
            });
            Task.Delay(this.Duration)
                .ContinueWith(_ => this.Cancel());
        }
    }
}
