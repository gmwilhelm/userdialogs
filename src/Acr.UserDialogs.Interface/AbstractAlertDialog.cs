using System;
using System.Threading;
using System.Threading.Tasks;


namespace Acr.UserDialogs {

    public abstract class AbstractAlertDialog : AbstractDialog, IAlertDialog {

        public virtual string Title { get; set; }
        public virtual string Message { get; set; }
        public virtual string OkText { get; set; } = DefaultOkText;

        public abstract void Show();
        public abstract Task Request(CancellationToken? cancelToken = null);


        public virtual IAlertDialog SetOkText(string text) {
            this.OkText = text ?? DefaultOkText;
            return this;
        }


        public virtual IAlertDialog SetTitle(string title) {
            this.Title = title;
            return this;
        }


        public virtual IAlertDialog SetMessage(string message) {
            this.Message = message;
            return this;
        }


        public static string DefaultOkText { get; set; } = "Ok";
    }
}