using System;
using System.Threading;
using System.Threading.Tasks;
using Splat;


namespace Acr.UserDialogs {

    public abstract class AbstractUserDialogs : IUserDialogs {

        public abstract IActionSheetDialog ActionSheetBuilder();
        public abstract IAlertDialog AlertBuilder();
        public abstract IConfirmDialog ConfirmBuilder();
        public abstract ILoginDialog LoginBuilder();
        public abstract IProgressDialog ProgressBuilder();
        public abstract IPromptDialog PromptBuilder();
        public abstract IToastDialog ToastBuilder();

        public abstract void ShowImage(IBitmap image, string message, int timeoutMillis);
        public abstract void ShowError(string message, int timeoutMillis);
        public abstract void ShowSuccess(string message, int timeoutMillis);



        public virtual Task<string> ActionSheetAsync(string title, string cancel, string destructive, params string[] buttons) {
            var tcs = new TaskCompletionSource<string>();
            var builder = this.ActionSheetBuilder()
                .SetTitle(title);

            if (cancel != null)
                builder.SetCancelOption(cancel, () => tcs.TrySetResult(cancel));

            if (destructive != null)
                builder.SetDestructiveOption(destructive, () => tcs.TrySetResult(destructive));

            foreach (var btn in buttons)
                builder.Add(btn, () => tcs.TrySetResult(btn));

            builder.Show();
            return tcs.Task;
        }


        public virtual void Alert(string message, string title = null, string okText = null) {
            this.AlertBuilder()
                .SetTitle(title)
                .SetMessage(message)
                .SetOkText(okText)
                .Show();
        }


        public virtual Task AlertAsync(string message, string title = null, string okText = null, CancellationToken? cancelToken = null) {
            return this.AlertBuilder()
                .SetTitle(title)
                .SetMessage(message)
                .SetOkText(okText)
                .Request(cancelToken);
        }


        public virtual Task<bool> ConfirmAsync(string message, string title = null, string okText = null, string cancelText = null, CancellationToken? cancelToken = null) {
            return this.ConfirmBuilder()
                .SetTitle(title)
                .SetMessage(message)
                .SetOkText(okText)
                .Request(cancelToken);
        }


        public virtual Task<LoginResult> LoginAsync(string title = null, string message = null, CancellationToken? cancelToken = null) {
            return this.LoginBuilder()
                .SetTitle(title)
                .SetMessage(message)
                .Request(cancelToken);
        }


        public virtual IProgressDialog Loading(string title = null, Action onCancel = null, string cancelText = null, bool show = true, MaskType? maskType = null) {
            throw new NotImplementedException();
        }


        public virtual IProgressDialog Progress(string title = null, Action onCancel = null, string cancelText = null, bool show = true, MaskType? maskType = null) {
            throw new NotImplementedException();
        }


        IProgressDialog showLoading;
        public virtual void ShowLoading(string title = null, MaskType? maskType = null) {
            if (this.showLoading == null)
                this.showLoading = this.Loading(title, null, null, true, maskType);
        }


        public virtual void HideLoading() {
            this.showLoading?.Dispose();
            this.showLoading = null;
        }


        public virtual Task<PromptResult> PromptAsync(string message, string title = null, string okText = null, string cancelText = null, string placeholder = "", InputType inputType = InputType.Default, CancellationToken? cancelToken = null) {
            return this.PromptBuilder()
                .SetTitle(title)
                .SetMessage(message)
                .SetOkText(okText)
                .SetCancelText(cancelText)
                .SetPlaceholderText(placeholder)
                .SetInputType(inputType)
                .Request(cancelToken);
        }


        public virtual void InfoToast(string title, string description = null, int timeoutMillis = 3000) {
            this.ToastBuilder()
                .SetEvent(ToastEvent.Info)
                .SetTitle(title)
                .SetDescription(description)
                .SetDuration(timeoutMillis)
                .Show();
        }


        public virtual void SuccessToast(string title, string description = null, int timeoutMillis = 3000) {
            this.ToastBuilder()
                .SetEvent(ToastEvent.Success)
                .SetTitle(title)
                .SetDescription(description)
                .SetDuration(timeoutMillis)
                .Show();
        }


        public virtual void WarnToast(string title, string description = null, int timeoutMillis = 3000) {
            this.ToastBuilder()
                .SetEvent(ToastEvent.Warn)
                .SetTitle(title)
                .SetDescription(description)
                .SetDuration(timeoutMillis)
                .Show();
        }


        public virtual void ErrorToast(string title, string description = null, int timeoutMillis = 3000) {
            this.ToastBuilder()
                .SetEvent(ToastEvent.Error)
                .SetTitle(title)
                .SetDescription(description)
                .SetDuration(timeoutMillis)
                .Show();
        }


		//public virtual ProgressDialog Loading(string title, Action onCancel, string cancelText, bool show, MaskType? maskType) {
  //          return this.Progress(new ProgressDialogConfig {
  //              Title = title ?? ProgressDialogConfig.DefaultTitle,
  //              AutoShow = show,
  //              CancelText = cancelText ?? ProgressDialogConfig.DefaultCancelText,
		//		MaskType = maskType ?? ProgressDialogConfig.DefaultMaskType,
  //              IsDeterministic = false,
  //              OnCancel = onCancel
  //          });
  //      }


		//public virtual ProgressDialog Progress(string title, Action onCancel, string cancelText, bool show, MaskType? maskType) {
		//	return this.Progress(new ProgressDialogConfig {
  //              Title = title ?? ProgressDialogConfig.DefaultTitle,
  //              AutoShow = show,
  //              CancelText = cancelText ?? ProgressDialogConfig.DefaultCancelText,
		//		MaskType = maskType ?? ProgressDialogConfig.DefaultMaskType,
  //              IsDeterministic = true,
  //              OnCancel = onCancel
  //          });
  //      }


		//public virtual ProgressDialog Progress(ProgressDialogConfig config) {
  //          var dlg = this.CreateDialogInstance();
  //          dlg.Title = config.Title;
  //          dlg.IsDeterministic = config.IsDeterministic;
		//	dlg.MaskType = config.MaskType;

  //          if (config.OnCancel != null)
  //              dlg.SetCancel(config.OnCancel, config.CancelText);

  //          if (config.AutoShow)
  //              dlg.Show();

  //          return dlg;
  //      }


  //      public virtual Task AlertAsync(string message, string title, string okText) {
  //          var tcs = new TaskCompletionSource<object>();
  //          this.Alert(new AlertConfig {
  //              Message = message,
  //              Title = title,
  //              OkText = okText ?? AlertConfig.DefaultOkText,
  //              OnOk = () => tcs.TrySetResult(null)
  //          });
  //          return tcs.Task;
  //      }

    }
}
