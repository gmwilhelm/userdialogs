using System;
using System.Threading;
using System.Threading.Tasks;


namespace Acr.UserDialogs {

    public abstract class LoginDialog : Dialog {

        public virtual string LoginValue { get; set; }
        public virtual string LoginPlaceholder { get; set; }
        public virtual string PasswordPlaceholder { get; set; }


        public abstract Task<LoginResult> Request(CancellationToken? cancelToken = null);
    }
}
