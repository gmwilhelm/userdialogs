using System;
using System.Threading;
using System.Threading.Tasks;


namespace Acr.UserDialogs {

    public interface IAlertDialog : IDialog {

        string Title { get; set; }
        string Message { get; set; }
        string OkText { get; set; }

        void Show();
        Task Request(CancellationToken? cancelToken = null);


        IAlertDialog SetOkText(string text);
        IAlertDialog SetTitle(string title);
        IAlertDialog SetMessage(string message);
    }
}
