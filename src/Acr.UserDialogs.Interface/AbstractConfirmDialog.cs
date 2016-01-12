using System;
using System.Threading;
using System.Threading.Tasks;


namespace Acr.UserDialogs {

    public abstract class AbstractConfirmDialog : AbstractDialog, IConfirmDialog {

        public virtual string Title { get; set; }
        public virtual string Message { get; set; }
        public virtual string OkText { get; set; }
        public virtual string CancelText { get; set; }
        public abstract Task<bool> Request(CancellationToken? cancelToken = null);


        public virtual IConfirmDialog SetOkText(string text) {
            this.OkText = text ?? DefaultOkText;
            return this;
        }


        public virtual IConfirmDialog SetCancelText(string text) {
            this.CancelText = text ?? DefaultCancelText;
            return this;
        }


        public virtual IConfirmDialog SetTitle(string title) {
            this.Title = title;
            return this;
        }


        public virtual IConfirmDialog SetMessage(string message) {
            this.Message = message;
            return this;
        }


        public virtual IConfirmDialog SetYesNoButtons(string yesText = null, string noText = null) {
            this.OkText = yesText ?? DefaultYes;
            this.CancelText = noText ?? DefaultNo;
            return this;
        }


        public static string DefaultYes { get; set; } = "Yes";
        public static string DefaultNo { get; set; } = "No";
        public static string DefaultOkText { get; set; } = "Ok";
        public static string DefaultCancelText { get; set; } = "Cancel";
    }
}