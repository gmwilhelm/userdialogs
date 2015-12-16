using System;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Text;
using Android.Text.Method;
using Android.Widget;
#if APPCOMPAT
using AD = Android.Support.V7.App.AlertDialog;
#else
using AD = Android.App.AlertDialog;
#endif


namespace Acr.UserDialogs {

    public class PromptDialogImpl : PromptDialog {
        AD dialog;
        readonly Activity activity;


        public PromptDialogImpl(Activity activity) {
            this.activity = activity;
        }


        public override Task<PromptResult> Request(CancellationToken? cancelToken) {
            var txt = new EditText(this.activity) {
                Hint = this.PlaceholderText
            };
			if (this.Text != null)
				txt.Text = this.Text;

            this.SetInputType(txt, this.InputType);

            throw new NotImplementedException();
        }


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
/*
            Utils.RequestMainThread(() => {
                var activity = this.GetTopActivity();



                var builder = new Android.App.AlertDialog
                    .Builder(activity)
                    .SetCancelable(false)
                    .SetMessage(config.Message)
                    .SetTitle(config.Title)
                    .SetView(txt)
                    .SetPositiveButton(config.OkText, (s, a) =>
                        config.OnResult(new PromptResult {
                            Ok = true,
                            Text = txt.Text
                        })
					);

				if (config.IsCancellable) {
					builder.SetNegativeButton(config.CancelText, (s, a) =>
                        config.OnResult(new PromptResult {
                            Ok = false,
                            Text = txt.Text
                        })
					);
				}

				builder.ShowExt();
            });

*/