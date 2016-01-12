using System;


namespace Acr.UserDialogs {

    public interface IDialog : IDisposable {

        bool IsVisible { get; }
        void Cancel();
    }
}
