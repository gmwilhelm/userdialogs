using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using Microsoft.Phone.Controls;


namespace Acr.UserDialogs {

    public class LoginDialogImpl : LoginDialog {
        CustomMessageBox messageBox;
        TaskCompletionSource<LoginResult> tcs;


        public override Task<LoginResult> Request(CancellationToken? cancelToken = null) {
            this.messageBox = new CustomMessageBox {
                Caption = this.Title,
                Message = this.Message,
                LeftButtonContent = this.OkText,
                RightButtonContent = this.CancelText
            };
            var txtUser = new PhoneTextBox {
                //PlaceholderText = config.LoginPlaceholder,
                Text = this.LoginValue ?? String.Empty
            };
            var txtPass = new PasswordBox();
            //var txtPass = new PhonePasswordBox {
                //PlaceholderText = config.PasswordPlaceholder
            //};
            var stack = new StackPanel();

            stack.Children.Add(txtUser);
            stack.Children.Add(txtPass);
            this.messageBox.Content = stack;

            this.messageBox.Dismissed += (sender, args) => this.tcs.TrySetResult(new LoginResult(
                txtUser.Text,
                txtPass.Password,
                args.Result == CustomMessageBoxResult.LeftButton
            ));
            //this.Dispatch(prompt.Show);
            return this.tcs.Task;
        }
    }
}