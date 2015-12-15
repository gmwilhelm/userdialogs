using System;
using System.Threading.Tasks;


namespace Acr.UserDialogs {

    public class PromptDialogImpl : PromptDialog {

        public override Task<PromptResult> Request() {
            throw new NotImplementedException();
        }
    }
}
/*
            Utils.RequestMainThread(() => {
                var activity = this.GetTopActivity();

                var txt = new EditText(activity) {
                    Hint = config.Placeholder
                };
				if (config.Text != null)
					txt.Text = config.Text;

                this.SetInputType(txt, config.InputType);


 Unmerged change from project 'Acr.UserDialogs.Android.AppCompat'
Before:
                var builder = new AlertDialog
After:
                var builder = new Android.Support.V7.App.AlertDialog

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
*/