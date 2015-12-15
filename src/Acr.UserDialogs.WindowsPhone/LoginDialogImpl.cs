using System;
using System.Threading;
using System.Threading.Tasks;


namespace Acr.UserDialogs {

    public class LoginDialogImpl : LoginDialog {

        public override Task<LoginResult> Request(CancellationToken? cancelToken = null) {
            throw new NotImplementedException();
        }
    }
}
/*
            var prompt = new CustomMessageBox {
                Caption = config.Title,
                Message = config.Message,
                LeftButtonContent = config.OkText,
                RightButtonContent = config.CancelText
            };
            var txtUser = new PhoneTextBox {
                //PlaceholderText = config.LoginPlaceholder,
                Text = config.LoginValue ?? String.Empty
            };
            var txtPass = new PasswordBox();
            //var txtPass = new PhonePasswordBox {
                //PlaceholderText = config.PasswordPlaceholder
            //};
            var stack = new StackPanel();

            stack.Children.Add(txtUser);
            stack.Children.Add(txtPass);
            prompt.Content = stack;

            prompt.Dismissed += (sender, args) => config.OnResult(new LoginResult(
                txtUser.Text,
                txtPass.Password,
                args.Result == CustomMessageBoxResult.LeftButton
            ));
            this.Dispatch(prompt.Show);
*/