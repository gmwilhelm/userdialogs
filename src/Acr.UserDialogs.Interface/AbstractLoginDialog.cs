using System;
using System.Threading;
using System.Threading.Tasks;


namespace Acr.UserDialogs {

    public abstract class AbstractLoginDialog : AbstractDialog, ILoginDialog {

        public virtual string Title { get; set; } = DefaultTitle;
        public virtual string Message { get; set; }
        public virtual string LoginValue { get; set; }
        public virtual string LoginPlaceholder { get; set; } = DefaultLoginPlaceholder;
        public virtual string PasswordPlaceholder { get; set; } = DefaultPasswordPlaceholder;
        public virtual string OkText { get; set; } = DefaultOkText;
        public virtual string CancelText { get; set; } = DefaultCancelText;

        public abstract Task<LoginResult> Request(CancellationToken? cancelToken = null);


        public virtual ILoginDialog SetTitle(string title) {
            this.Title = title;
            return this;
        }


        public virtual ILoginDialog SetMessage(string msg) {
            this.Message = msg;
            return this;
        }


        public virtual ILoginDialog SetOkText(string ok) {
            this.OkText = ok ?? DefaultOkText;
            return this;
        }


        public virtual ILoginDialog SetCancelText(string cancel) {
            this.CancelText = cancel ?? DefaultCancelText;
            return this;
        }


        public virtual ILoginDialog SetLoginValue(string txt) {
            this.LoginValue = txt;
            return this;
        }


        public virtual ILoginDialog SetLoginPlaceholder(string txt) {
            this.LoginPlaceholder = txt;
            return this;
        }


        public virtual ILoginDialog SetPasswordPlaceholder(string txt) {
            this.PasswordPlaceholder = txt;
            return this;
        }


        public static string DefaultTitle { get; set; } = "Login";
        public static string DefaultOkText { get; set; } = "Ok";
        public static string DefaultCancelText { get; set; } = "Cancel";
        public static string DefaultLoginPlaceholder { get; set; } = "User Name";
        public static string DefaultPasswordPlaceholder { get; set; } = "Password";
    }
}
