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
            var context = this.GetTopActivity();
            var txtUser = new EditText(context) {
                Hint = config.LoginPlaceholder,
                InputType = InputTypes.TextVariationVisiblePassword,
                Text = config.LoginValue ?? String.Empty
            };
            var txtPass = new EditText(context) {
                Hint = config.PasswordPlaceholder ?? "*"
            };
            this.SetInputType(txtPass, InputType.Password);

            var layout = new LinearLayout(context) {
                Orientation = Orientation.Vertical
            };

            txtUser.SetMaxLines(1);
            txtPass.SetMaxLines(1);

            layout.AddView(txtUser, ViewGroup.LayoutParams.MatchParent);
            layout.AddView(txtPass, ViewGroup.LayoutParams.MatchParent);

            Utils.RequestMainThread(() =>

 Unmerged change from project 'Acr.UserDialogs.Android.AppCompat'
Before:
                new AlertDialog
After:
                new Android.Support.V7.App.AlertDialog

                new Android.App.AlertDialog
                    .Builder(context)
                    .SetCancelable(false)
                    .SetTitle(config.Title)
                    .SetMessage(config.Message)
                    .SetView(layout)
                    .SetPositiveButton(config.OkText, (s, a) =>
                        config.OnResult(new LoginResult(txtUser.Text, txtPass.Text, true))
                    )
                    .SetNegativeButton(config.CancelText, (s, a) =>
                        config.OnResult(new LoginResult(txtUser.Text, txtPass.Text, false))
                    )
                    .ShowExt()
            );
*/