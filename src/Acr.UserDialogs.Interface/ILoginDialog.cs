using System;
using System.Threading;
using System.Threading.Tasks;


namespace Acr.UserDialogs {

    public interface ILoginDialog : IDialog {

        string Title { get; set; }
        string Message { get; set; }
        string LoginValue { get; set; }
        string LoginPlaceholder { get; set; }
        string PasswordPlaceholder { get; set; }
        string OkText { get; set; }
        string CancelText { get; set; }

        Task<LoginResult> Request(CancellationToken? cancelToken = null);


        ILoginDialog SetTitle(string title);
        ILoginDialog SetMessage(string msg);
        ILoginDialog SetOkText(string ok);
        ILoginDialog SetCancelText(string cancel);
        ILoginDialog SetLoginValue(string txt);
        ILoginDialog SetLoginPlaceholder(string txt);
        ILoginDialog SetPasswordPlaceholder(string txt);
    }
}
