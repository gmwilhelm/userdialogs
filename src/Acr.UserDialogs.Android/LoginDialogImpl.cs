using System;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Text;
using Android.Text.Method;
using Android.Views;
using Android.Widget;
#if APPCOMPAT
using AD = Android.Support.V7.App.AlertDialog;
#else
using AD = Android.App.AlertDialog;
#endif


namespace Acr.UserDialogs {

    public class LoginDialogImpl : LoginDialog {
        readonly Activity activity;
        TaskCompletionSource<LoginResult> tcs;
        AD dialog;


        public LoginDialogImpl(Activity activity) {
            this.activity = activity;
        }


        public override Task<LoginResult> Request(CancellationToken? cancelToken = null) {
            this.tcs = new TaskCompletionSource<LoginResult>();

            var txtUser = new EditText(this.activity) {
                Hint = this.LoginPlaceholder,
                InputType = InputTypes.TextVariationVisiblePassword,
                Text = this.LoginValue ?? String.Empty
            };
            var txtPass = new EditText(this.activity) {
                Hint = this.PasswordPlaceholder ?? "*"
            };
            this.SetInputType(txtPass, InputType.Password);

            var layout = new LinearLayout(this.activity) {
                Orientation = Orientation.Vertical
            };

            txtUser.SetMaxLines(1);
            txtPass.SetMaxLines(1);

            layout.AddView(txtUser, ViewGroup.LayoutParams.MatchParent);
            layout.AddView(txtPass, ViewGroup.LayoutParams.MatchParent);

            //Utils.RequestMainThread(() =>


                this.dialog = new AD
                    .Builder(this.activity)
                    .SetCancelable(false)
                    .SetTitle(this.Title)
                    .SetMessage(this.Message)
                    .SetView(layout)
                    .SetPositiveButton(this.OkText, (s, a) =>
                        this.tcs.TrySetResult(new LoginResult(txtUser.Text, txtPass.Text, true))
                    )
                    .SetNegativeButton(this.CancelText, (s, a) =>
                        this.tcs.TrySetResult(new LoginResult(txtUser.Text, txtPass.Text, false))
                    )
                    .ShowExt();
            //);

            return this.tcs.Task;
        }


        // TODO: this needs to be reused
        protected virtual void SetInputType(TextView txt, InputType inputType) {
            switch (inputType) {
                case InputType.DecimalNumber:
                    txt.InputType = InputTypes.ClassNumber | InputTypes.NumberFlagDecimal;
                    txt.SetSingleLine(true);
                    break;

                case InputType.Email:
                    txt.InputType = InputTypes.ClassText | InputTypes.TextVariationEmailAddress;
                    txt.SetSingleLine(true);
                    break;

				case InputType.Name:
					txt.InputType = InputTypes.TextVariationPersonName;
                    txt.SetSingleLine(true);
					break;

                case InputType.Number:
                    txt.InputType = InputTypes.ClassNumber;
                    txt.SetSingleLine(true);
                    break;

                case InputType.NumericPassword:
                    txt.InputType = InputTypes.ClassNumber;
                    txt.TransformationMethod = PasswordTransformationMethod.Instance;
                    break;

                case InputType.Password:
                    txt.TransformationMethod = PasswordTransformationMethod.Instance;
                    txt.InputType = InputTypes.ClassText | InputTypes.TextVariationPassword;
                    break;

				case InputType.Phone:
					txt.InputType = InputTypes.ClassPhone;
                    txt.SetSingleLine(true);
					break;

				case InputType.Url:
					txt.InputType = InputTypes.TextVariationUri;
                    txt.SetSingleLine(true);
					break;
            }
        }
    }
}