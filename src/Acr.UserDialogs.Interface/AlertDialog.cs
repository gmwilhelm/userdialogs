using System;
using System.Threading;
using System.Threading.Tasks;


namespace Acr.UserDialogs {

    public abstract class AlertDialog : Dialog {

        public virtual string Title { get; set; }
        public virtual string Message { get; set; }
        public virtual ActionOption Ok { get; set; }
        public virtual ActionOption Cancel { get; set; }
        public abstract Task<bool> Request(CancellationToken? cancelToken = null);

        public static string DefaultYes { get; set; } = "Yes";
        public static string DefaultNo { get; set; } = "No";
        public static string DefaultOkText { get; set; } = "Ok";
        public static string DefaultCancelText { get; set; } = "Cancel";
    }
}
/*



        public AlertConfig() {
            this.OkText = DefaultOkText;
        }


        public AlertConfig SetOkText(string text) {
            this.OkText = text;
            return this;
        }


        public AlertConfig SetTitle(string title) {
            this.Title = title;
            return this;
        }


        public AlertConfig SetMessage(string message) {
            this.Message = message;
            return this;
        }


        public AlertConfig SetCallback(Action onOk) {
            this.OnOk = onOk;
            return this;
        }
*/