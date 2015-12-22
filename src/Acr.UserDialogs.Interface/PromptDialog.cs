using System;
using System.Threading;
using System.Threading.Tasks;


namespace Acr.UserDialogs {

    public abstract class PromptDialog : Dialog {

        public virtual string Title { get; set; }
        public virtual string Message { get; set; }
        public virtual string PlaceholderText { get; set; }
        public bool IsCancellable { get; set; } = true;
		public string Text { get; set; } // TODO: could make this INPC with text
        public virtual InputType InputType { get; set; }
        public virtual string OkText { get; set; } = DefaultOkText;
        public virtual string CancelText { get; set; } = DefaultCancelText;


        public abstract Task<PromptResult> Request(CancellationToken? cancelToken = null);


        public virtual PromptDialog SetTitle(string title) {
            this.Title = title;
            return this;
        }


        public virtual PromptDialog SetMessage(string message) {
            this.Message = message;
            return this;
        }


		public virtual PromptDialog SetCancellable(bool cancel) {
			this.IsCancellable = cancel;
			return this;
		}


        public virtual PromptDialog SetOkText(string text) {
            this.OkText = text;
            return this;
        }


		public virtual PromptDialog SetText(string text) {
			this.Text = text;
			return this;
		}


        public virtual PromptDialog SetCancelText(string cancelText) {
			this.IsCancellable = true;
            this.CancelText = cancelText;
            return this;
        }


        public virtual PromptDialog SetPlaceholderText(string placeholder) {
            this.PlaceholderText = placeholder;
            return this;
        }


        public virtual PromptDialog SetInputType(InputType inputType) {
            this.InputType = inputType;
            return this;
        }


        public static string DefaultOkText { get; set; } = "Ok";
        public static string DefaultCancelText { get; set; } = "Cancel";
    }
}
