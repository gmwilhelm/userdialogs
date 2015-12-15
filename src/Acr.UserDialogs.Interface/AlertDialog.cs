using System;
using System.Threading;
using System.Threading.Tasks;


namespace Acr.UserDialogs {

    public abstract class AlertDialog : Dialog {

        public virtual string Title { get; set; }
        public virtual string Message { get; set; }
        public virtual string OkText { get; set; }

        public abstract void Show();
        public abstract Task Request(CancellationToken? cancelToken = null);


        public virtual AlertDialog SetOkText(string text) {
            this.OkText = text;
            return this;
        }


        public virtual AlertDialog SetTitle(string title) {
            this.Title = title;
            return this;
        }


        public virtual AlertDialog SetMessage(string message) {
            this.Message = message;
            return this;
        }


        public static string DefaultOkText { get; set; } = "Ok";
    }
}