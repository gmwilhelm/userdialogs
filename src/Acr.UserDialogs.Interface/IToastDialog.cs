using System;
using System.Drawing;
using Splat;


namespace Acr.UserDialogs {

    public interface IToastDialog : IDialog {

        ToastPosition Position { get; set; }

        void Show();
        string Title { get; set; }
        string Description { get; set; }

        Color BackgroundColor { get; set; }
        IBitmap Icon { get; set; }

        Color TextColor { get; set; }
        TimeSpan Duration { get; set; }
        Action Action { get; set; }

        IToastDialog SetEvent(ToastEvent @event);
        IToastDialog SetTitle(string title);
        IToastDialog SetDescription(string description);
        IToastDialog SetDuration(int millis);
        IToastDialog SetDuration(TimeSpan duration);
        IToastDialog SetIcon(IBitmap bitmap);
        IToastDialog SetColorList(Color? bg, Color? text);
        IToastDialog SetAction(Action action);
    }
}
