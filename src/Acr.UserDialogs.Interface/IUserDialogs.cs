using System;
using System.Threading;
using System.Threading.Tasks;
using Splat;


namespace Acr.UserDialogs {

    public interface IUserDialogs {

        // ACTION SHEET
        Task<string> ActionSheetAsync(string title, string cancel, string destructive, params string[] buttons);
        ActionSheetDialog ActionSheetBuilder();


        // ALERT
        AlertDialog AlertBuilder();
        void Alert(string message, string title = null, string okText = null);
        Task AlertAsync(string message, string title = null, string okText = null, CancellationToken? cancelToken = null);


        // CONFIRM
        Task<bool> ConfirmAsync(string message, string title = null, string okText = null, string cancelText = null, CancellationToken? cancelToken = null);
        ConfirmDialog ConfirmBuilder();


        // LOGIN
        LoginDialog LoginBuilder();
        Task<LoginResult> LoginAsync(string title = null, string message = null, CancellationToken? cancelToken = null);


        // PROGRESS
        ProgressDialog ProgressBuilder();
		ProgressDialog Loading(string title = null, Action onCancel = null, string cancelText = null, bool show = true, MaskType? maskType = null);
		ProgressDialog Progress(string title = null, Action onCancel = null, string cancelText = null, bool show = true, MaskType? maskType = null);
		void ShowLoading(string title = null, MaskType? maskType = null);
        void HideLoading();


        // PROMPT
        PromptDialog PromptBuilder();
        Task<PromptResult> PromptAsync(string message, string title = null, string okText = null, string cancelText = null, string placeholder = "", InputType inputType = InputType.Default);


        // TOASTS
        void ShowImage(IBitmap image, string message, int timeoutMillis = 3000);
        void ShowSuccess(string message, int timeoutMillis = 3000);
        void ShowError(string message, int timeoutMillis = 3000);

        void InfoToast(string title, string description = null, int timeoutMillis = 3000);
        void SuccessToast(string title, string description = null, int timeoutMillis = 3000);
        void WarnToast(string title, string description = null, int timeoutMillis = 3000);
        void ErrorToast(string title, string description = null, int timeoutMillis = 3000);
        ToastDialog ToastBuilder();
    }
}