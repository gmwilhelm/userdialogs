using System;
using System.Threading;
using System.Threading.Tasks;
using Acr.Support.iOS;
using UIKit;


namespace Acr.UserDialogs {

    public class LoginDialogImpl : LoginDialog {
        readonly AlertDialogManager<LoginResult> manager = new AlertDialogManager<LoginResult>();


        public override async Task<LoginResult> Request(CancellationToken? cancelToken = null) {
            cancelToken?.Register(this.Cancel);
            this.manager.AssertFree();

            if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
                this.Ver8();
            else
                this.Ver7();

            var result = await this.manager.Tcs.Task;
            this.manager.Free();
            return result;
        }


        public override void Cancel() {
            base.Cancel();
            this.manager.Free();
        }


        protected virtual void Ver8() {
            UITextField txtUser = null;
            UITextField txtPass = null;

            var dlg = UIAlertController.Create(
                this.Title ?? String.Empty,
                this.Message ?? String.Empty,
                UIAlertControllerStyle.Alert
            );
            this.manager.Alloc(dlg);

            dlg.AddAction(UIAlertAction.Create(
                this.CancelText,
                UIAlertActionStyle.Cancel,
                x => this.manager.Tcs.TrySetResult(new LoginResult(txtUser.Text, txtPass.Text, false))
            ));
            dlg.AddAction(UIAlertAction.Create(
                this.OkText,
                UIAlertActionStyle.Default,
                x => this.manager.Tcs.TrySetResult(new LoginResult(txtUser.Text, txtPass.Text, true))
            ));

            dlg.AddTextField(x => {
                txtUser = x;
                x.Placeholder = this.LoginPlaceholder;
                x.Text = this.LoginValue ?? String.Empty;
            });
            dlg.AddTextField(x => {
                txtPass = x;
                x.Placeholder = this.PasswordPlaceholder;
                x.SecureTextEntry = true;
            });
            UIApplication.SharedApplication.Present(dlg);
        }


        protected virtual void Ver7() {
            var dlg = new UIAlertView {
                AlertViewStyle = UIAlertViewStyle.LoginAndPasswordInput,
                Title = this.Title,
				Message = this.Message
            };
            this.manager.Alloc(dlg);

            var txtUser = dlg.GetTextField(0);
            var txtPass = dlg.GetTextField(1);

            txtUser.Placeholder = this.LoginPlaceholder;
            txtUser.Text = this.LoginValue ?? String.Empty;
            txtPass.Placeholder = this.PasswordPlaceholder;

            dlg.AddButton(this.OkText);
            dlg.AddButton(this.CancelText);
            dlg.CancelButtonIndex = 1;

            dlg.Clicked += (s, e) => {
                var ok = (int)dlg.CancelButtonIndex != (int)e.ButtonIndex;
                this.manager.Tcs.TrySetResult(new LoginResult(txtUser.Text, txtPass.Text, ok));
            };
            UIApplication.SharedApplication.InvokeOnMainThread(dlg.Show);
        }
    }
}