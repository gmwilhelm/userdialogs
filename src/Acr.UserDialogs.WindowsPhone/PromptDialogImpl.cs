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
            var prompt = new CustomMessageBox {
                Caption = config.Title,
                Message = config.Message,
                LeftButtonContent = config.OkText
            };
			if (config.IsCancellable)
				prompt.RightButtonContent = config.CancelText;

            var password = new PasswordBox();
            var inputScope = this.GetInputScope(config.InputType);
            var txt = new PhoneTextBox {
                //PlaceholderText = config.Placeholder,
                InputScope = inputScope
            };
			if (config.Text != null)
				txt.Text = config.Text;

            var isSecure = (config.InputType == InputType.NumericPassword || config.InputType == InputType.Password);
            if (isSecure)
                prompt.Content = password;
            else
                prompt.Content = txt;

            prompt.Dismissed += (sender, args) => config.OnResult(new PromptResult {
                Ok = args.Result == CustomMessageBoxResult.LeftButton,
                Text = isSecure
                    ? password.Password
                    : txt.Text.Trim()
            });
            this.Dispatch(prompt.Show);


        protected virtual InputScope GetInputScope(InputType inputType) {
            var name = new InputScopeName();
            var scope = new InputScope();

            switch (inputType) {
                case InputType.Email:
                    name.NameValue = InputScopeNameValue.EmailNameOrAddress;
                    break;

                case InputType.DecimalNumber:
                    name.NameValue = InputScopeNameValue.Digits;
                    break;

                case InputType.Name:
                    name.NameValue = InputScopeNameValue.PersonalFullName;
                    break;

                case InputType.Number:
                    name.NameValue = InputScopeNameValue.Number;
                    break;

                case InputType.NumericPassword:
                    name.NameValue = InputScopeNameValue.NumericPassword;
                    break;

                case InputType.Phone:
                    name.NameValue = InputScopeNameValue.NameOrPhoneNumber;
                    break;

                case InputType.Url:
                    name.NameValue = InputScopeNameValue.Url;
                    break;

				default:
                    name.NameValue = InputScopeNameValue.Default;
                    break;
            }
            scope.Names.Add(name);
            return scope;
        }
*/