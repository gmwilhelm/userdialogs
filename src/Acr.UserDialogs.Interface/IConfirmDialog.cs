using System;
using System.Threading;
using System.Threading.Tasks;


namespace Acr.UserDialogs {

    public interface IConfirmDialog : IDialog {

        string Title { get; set; }
        string Message { get; set; }
        string OkText { get; set; }
        string CancelText { get; set; }
        Task<bool> Request(CancellationToken? cancelToken = null);


        IConfirmDialog SetOkText(string text);
        IConfirmDialog SetCancelText(string text);
        IConfirmDialog SetTitle(string title);
        IConfirmDialog SetMessage(string message);
        IConfirmDialog SetYesNoButtons(string yesText = null, string noText = null);
    }
}
