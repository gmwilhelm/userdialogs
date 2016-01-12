using System;
using System.Threading;
using System.Threading.Tasks;


namespace Acr.UserDialogs {

    public abstract class AbstractPromptDialog : AbstractDialog, IPromptDialog {

        public virtual string Title { get; set; }
        public virtual string Message { get; set; }
        public virtual string PlaceholderText { get; set; }
        public virtual bool IsCancellable { get; set; } = true;
		public virtual string Text { get; set; } // TODO: could make this INPC with text
        public virtual InputType InputType { get; set; }
        public virtual string OkText { get; set; } = DefaultOkText;
        public virtual string CancelText { get; set; } = DefaultCancelText;


        public abstract Task<PromptResult> Request(CancellationToken? cancelToken = null);


        public virtual IPromptDialog SetTitle(string title) {
            this.Title = title;
            return this;
        }


        public virtual IPromptDialog SetMessage(string message) {
            this.Message = message;
            return this;
        }


		public virtual IPromptDialog SetCancellable(bool cancel) {
			this.IsCancellable = cancel;
			return this;
		}


        public virtual IPromptDialog SetOkText(string text) {
            this.OkText = text ?? DefaultOkText;
            return this;
        }


		public virtual IPromptDialog SetText(string text) {
			this.Text = text;
			return this;
		}


        public virtual IPromptDialog SetCancelText(string cancelText) {
			this.IsCancellable = true;
            this.CancelText = cancelText ?? DefaultCancelText;
            return this;
        }


        public virtual IPromptDialog SetPlaceholderText(string placeholder) {
            this.PlaceholderText = placeholder;
            return this;
        }


        public virtual IPromptDialog SetInputType(InputType inputType) {
            this.InputType = inputType;
            return this;
        }


        public static string DefaultOkText { get; set; } = "Ok";
        public static string DefaultCancelText { get; set; } = "Cancel";
    }
}
