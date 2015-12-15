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
            UITextField txtUser = null;
            UITextField txtPass = null;

            if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0)) {
                var dlg = UIAlertController.Create(config.Title ?? String.Empty, config.Message, UIAlertControllerStyle.Alert);
                dlg.AddAction(UIAlertAction.Create(config.CancelText, UIAlertActionStyle.Cancel, x => config.OnResult(new LoginResult(txtUser.Text, txtPass.Text, false))));
                dlg.AddAction(UIAlertAction.Create(config.OkText, UIAlertActionStyle.Default, x => config.OnResult(new LoginResult(txtUser.Text, txtPass.Text, true))));

                dlg.AddTextField(x => {
                    txtUser = x;
                    x.Placeholder = config.LoginPlaceholder;
                    x.Text = config.LoginValue ?? String.Empty;
                });
                dlg.AddTextField(x => {
                    txtPass = x;
                    x.Placeholder = config.PasswordPlaceholder;
                    x.SecureTextEntry = true;
                });
                this.Present(dlg);
            }
            else {
                var dlg = new UIAlertView {
                    AlertViewStyle = UIAlertViewStyle.LoginAndPasswordInput,
                    Title = config.Title,
					Message = config.Message
                };
                txtUser = dlg.GetTextField(0);
                txtPass = dlg.GetTextField(1);

                txtUser.Placeholder = config.LoginPlaceholder;
                txtUser.Text = config.LoginValue ?? String.Empty;
                txtPass.Placeholder = config.PasswordPlaceholder;

                dlg.AddButton(config.OkText);
                dlg.AddButton(config.CancelText);
                dlg.CancelButtonIndex = 1;

                dlg.Clicked += (s, e) => {
                    var ok = ((int)dlg.CancelButtonIndex != (int)e.ButtonIndex);
                    config.OnResult(new LoginResult(txtUser.Text, txtPass.Text, ok));
                };
                this.Present(dlg);
            }
*/