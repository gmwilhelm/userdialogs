using System;
using System.Threading;
using System.Threading.Tasks;


namespace Acr.UserDialogs {

    public interface IPromptDialog : IDialog {

        string Title { get; set; }
        string Message { get; set; }
        string PlaceholderText { get; set; }
        bool IsCancellable { get; set; }
		string Text { get; set; }
        InputType InputType { get; set; }
        string OkText { get; set; }
        string CancelText { get; set; }


        Task<PromptResult> Request(CancellationToken? cancelToken = null);


        IPromptDialog SetTitle(string title);
        IPromptDialog SetMessage(string message);
		IPromptDialog SetCancellable(bool cancel);
        IPromptDialog SetOkText(string text);
		IPromptDialog SetText(string text);
        IPromptDialog SetCancelText(string cancelText);
        IPromptDialog SetPlaceholderText(string placeholder);
        IPromptDialog SetInputType(InputType inputType);
    }
}
