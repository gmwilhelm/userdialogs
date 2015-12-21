using System;
using System.Drawing;
using Splat;


namespace Acr.UserDialogs {

    public abstract class ToastDialog : Dialog {
        public virtual ToastPosition Position { get; set; } = ToastPosition.Top; // only works on iOS at the moment

        public abstract void Show();
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }

        public virtual Color BackgroundColor { get; set; }
        public virtual IBitmap Icon { get; set; }

        public virtual Color TextColor { get; set; }
        public virtual TimeSpan Duration { get; set; }
        public virtual Action Action { get; set; }


        public virtual ToastDialog SetEvent(ToastEvent @event) {
            switch (@event) {
                case ToastEvent.Info:
                    this.BackgroundColor = InfoBackgroundColor;
                    this.TextColor = InfoTextColor;
                    this.Icon = InfoIcon;
                    break;

                case ToastEvent.Success:
                    this.BackgroundColor = SuccessBackgroundColor;
                    this.TextColor = SuccessTextColor;
                    this.Icon = SuccessIcon;
                    break;

                case ToastEvent.Warn:
                    this.BackgroundColor = WarnBackgroundColor;
                    this.TextColor = WarnTextColor;
                    this.Icon = WarnIcon;
                    break;

                case ToastEvent.Error:
                    this.BackgroundColor = ErrorBackgroundColor;
                    this.TextColor = ErrorTextColor;
                    this.Icon = ErrorIcon;
                    break;
            }
            return this;
        }


        public virtual ToastDialog SetTitle(string title) {
            this.Title = title;
            return this;
        }


        public virtual ToastDialog SetDescription(string description) {
            this.Description = description;
            return this;
        }


        public virtual ToastDialog SetDuration(int millis) {
            return this.SetDuration(TimeSpan.FromMilliseconds(millis));
        }


        public virtual ToastDialog SetDuration(TimeSpan duration) {
            this.Duration = duration;
            return this;
        }


        public virtual ToastDialog SetIcon(IBitmap bitmap) {
            this.Icon = bitmap;
            return this;
        }


        public virtual ToastDialog SetColorList(Color? bg, Color? text) {
            if (bg != null) this.BackgroundColor = bg.Value;
            if (text != null) this.TextColor = text.Value;
            return this;
        }


        public virtual ToastDialog SetAction(Action action) {
            this.Action = action;
            return this;
        }


        public static IBitmap InfoIcon { get; set; }
        public static Color InfoBackgroundColor { get; set; } = Color.Gainsboro; //Color.FromArgb(96, 0, 482, 1);
        public static Color InfoTextColor { get; set; } = Color.Black;

        public static IBitmap SuccessIcon { get; set; }
        public static Color SuccessBackgroundColor { get; set; } = Color.LawnGreen; //Color.FromArgb(96, 0, 831, 176);
        public static Color SuccessTextColor { get; set; } = Color.Black;

        public static IBitmap WarnIcon { get; set; }
        public static Color WarnBackgroundColor { get; set; } = Color.Coral;
        public static Color WarnTextColor { get; set; } = Color.White;

        public static IBitmap ErrorIcon { get; set; }
        public static Color ErrorBackgroundColor { get; set; } = Color.Red;
        public static Color ErrorTextColor { get; set; } = Color.White;

        public static TimeSpan DefaultDuration { get; set; } = TimeSpan.FromSeconds(2.5);
    }
}