using System;
using System.Threading;
using System.Threading.Tasks;
using Splat;


namespace Acr.UserDialogs {

    public abstract class AbstractUserDialogs : IUserDialogs {

        public abstract ActionSheetDialog ActionSheetBuilder();
        public abstract AlertDialog AlertBuilder();
        public abstract ConfirmDialog ConfirmBuilder();
        public abstract LoginDialog LoginBuilder();
        public abstract ProgressDialog ProgressBuilder();
        public abstract PromptDialog PromptBuilder();
        public abstract ToastDialog ToastBuilder();

        public abstract void ShowImage(IBitmap image, string message, int timeoutMillis);
        public abstract void ShowError(string message, int timeoutMillis);
        public abstract void ShowSuccess(string message, int timeoutMillis);



        public virtual Task<string> ActionSheetAsync(string title, string cancel, string destructive, params string[] buttons) {
            var tcs = new TaskCompletionSource<string>();
            var builder = this.ActionSheetBuilder()
                .SetTitle(title);

            if (cancel != null)
                builder.CancelOption = new ActionOption(cancel, () => tcs.TrySetResult(cancel));

            if (destructive != null)
                builder.DestructiveOption = new ActionOption(destructive, () => tcs.TrySetResult(destructive));

            foreach (var btn in buttons)
                builder.Add(btn, () => tcs.TrySetResult(btn));

            builder.Show();
            return tcs.Task;
        }


        public virtual void Alert(string message, string title = null, string okText = null) {
            throw new NotImplementedException();
        }


        public virtual Task AlertAsync(string message, string title = null, string okText = null, CancellationToken? cancelToken = null) {
            throw new NotImplementedException();
        }


        public virtual Task<bool> ConfirmAsync(string message, string title = null, string okText = null, string cancelText = null, CancellationToken? cancelToken = null) {
            throw new NotImplementedException();
        }


        public virtual Task<LoginResult> LoginAsync(string title = null, string message = null, CancellationToken? cancelToken = null) {
            throw new NotImplementedException();
        }


        public virtual ProgressDialog Loading(string title = null, Action onCancel = null, string cancelText = null, bool show = true, MaskType? maskType = null) {
            throw new NotImplementedException();
        }


        public virtual ProgressDialog Progress(string title = null, Action onCancel = null, string cancelText = null, bool show = true, MaskType? maskType = null) {
            throw new NotImplementedException();
        }


        public virtual void ShowLoading(string title = null, MaskType? maskType = null) {
            throw new NotImplementedException();
        }


        public virtual void HideLoading() {
            throw new NotImplementedException();
        }


        public virtual Task<PromptResult> PromptAsync(string message, string title = null, string okText = null, string cancelText = null, string placeholder = "", InputType inputType = InputType.Default) {
            throw new NotImplementedException();
        }


        public virtual void InfoToast(string title, string description = null, int timeoutMillis = 3000) {
            throw new NotImplementedException();
        }


        public virtual void SuccessToast(string title, string description = null, int timeoutMillis = 3000) {
            throw new NotImplementedException();
        }


        public virtual void WarnToast(string title, string description = null, int timeoutMillis = 3000) {
            throw new NotImplementedException();
        }


        public virtual void ErrorToast(string title, string description = null, int timeoutMillis = 3000) {
            throw new NotImplementedException();
        }



  //      public virtual void Alert(string message, string title, string okText) {
  //          this.Alert(new AlertConfig {
  //              Message = message,
  //              Title = title,
  //              OkText = okText ?? AlertConfig.DefaultOkText
  //          });
  //      }


  //      private ProgressDialog loading;
		//public virtual void ShowLoading(string title, MaskType? maskType) {
  //          if (this.loading == null)
		//		this.loading = this.Loading(title, null, null, true, maskType);
  //      }


  //      public virtual void HideLoading() {
  //          this.loading?.Dispose();
  //          this.loading = null;
  //      }


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


  //      public virtual Task AlertAsync(AlertConfig config) {
  //          var tcs = new TaskCompletionSource<object>();
  //          config.OnOk = () => tcs.TrySetResult(null);
  //          this.Alert(config);
  //          return tcs.Task;
  //      }


  //      public virtual Task<bool> ConfirmAsync(string message, string title, string okText, string cancelText) {
  //          var tcs = new TaskCompletionSource<bool>();
  //          this.Confirm(new ConfirmConfig {
  //              Message = message,
  //              Title = title,
  //              CancelText = cancelText ?? ConfirmConfig.DefaultCancelText,
  //              OkText = okText ?? ConfirmConfig.DefaultOkText,
  //              OnConfirm = x => tcs.TrySetResult(x)
  //          });
  //          return tcs.Task;
  //      }


  //      public virtual Task<bool> ConfirmAsync(ConfirmConfig config) {
  //          var tcs = new TaskCompletionSource<bool>();
  //          config.OnConfirm = x => tcs.TrySetResult(x);
  //          this.Confirm(config);
  //          return tcs.Task;
  //      }


  //      public virtual Task<LoginResult> LoginAsync(string title, string message) {
  //          return this.LoginAsync(new LoginConfig {
  //              Title = title ?? LoginConfig.DefaultTitle,
  //              Message = message
  //          });
  //      }


  //      public virtual Task<LoginResult> LoginAsync(LoginConfig config) {
  //          var tcs = new TaskCompletionSource<LoginResult>();
  //          config.OnResult = x => tcs.TrySetResult(x);
  //          this.Login(config);
  //          return tcs.Task;
  //      }


  //      public virtual Task<PromptResult> PromptAsync(string message, string title, string okText, string cancelText, string placeholder, InputType inputType) {
  //          var tcs = new TaskCompletionSource<PromptResult>();
  //          this.Prompt(new PromptConfig {
  //              Message = message,
  //              Title = title,
  //              CancelText = cancelText ?? PromptConfig.DefaultCancelText,
  //              OkText = okText ?? PromptConfig.DefaultOkText,
  //              Placeholder = placeholder,
  //              InputType = inputType,
  //              OnResult = x => tcs.TrySetResult(x)
  //          });
  //          return tcs.Task;
  //      }


  //      public virtual Task<PromptResult> PromptAsync(PromptConfig config) {
  //          var tcs = new TaskCompletionSource<PromptResult>();
  //          config.OnResult = x => tcs.TrySetResult(x);
  //          this.Prompt(config);
  //          return tcs.Task;
  //      }


  //      public virtual void InfoToast(string title, string description, int timeoutMillis) {
  //          this.Toast(ToastEvent.Info, title, description, timeoutMillis);
  //      }


  //      public virtual void SuccessToast(string title, string description, int timeoutMillis) {
  //          this.Toast(ToastEvent.Success, title, description, timeoutMillis);
  //      }


  //      public virtual void WarnToast(string title, string description, int timeoutMillis) {
  //          this.Toast(ToastEvent.Warn, title, description, timeoutMillis);
  //      }


  //      public virtual void ErrorToast(string title, string description, int timeoutMillis) {
  //          this.Toast(ToastEvent.Error, title, description, timeoutMillis);
  //      }


  //      public virtual void Toast(ToastEvent toastEvent, string title, string description, int timeoutMillis) {
  //          this.Toast(new ToastConfig(toastEvent, title) {
  //              Description = description,
  //              Duration = TimeSpan.FromMilliseconds(timeoutMillis)
  //          });
  //      }
    }
}
