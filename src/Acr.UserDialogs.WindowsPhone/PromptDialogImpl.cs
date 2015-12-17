using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Phone.Controls;


namespace Acr.UserDialogs {

    public class PromptDialogImpl : PromptDialog {
        CustomMessageBox messageBox;
        TaskCompletionSource<PromptResult> tcs;


        public override Task<PromptResult> Request(CancellationToken? cancelToken) {
            this.messageBox = new CustomMessageBox {
                Caption = this.Title,
                Message = this.Message,
                LeftButtonContent = this.OkText
            };
			if (this.IsCancellable)
				this.messageBox.RightButtonContent = this.CancelText;

            var password = new PasswordBox();
            var inputScope = this.GetInputScope(this.InputType);
            var txt = new PhoneTextBox {
                //PlaceholderText = config.Placeholder,
                InputScope = inputScope
            };
			if (this.Text != null)
				txt.Text = this.Text;

            var isSecure = this.InputType == InputType.NumericPassword || this.InputType == InputType.Password;
            if (isSecure)
                this.messageBox.Content = password;
            else
                this.messageBox.Content = txt;

            this.messageBox.Dismissed += (sender, args) => this.tcs.TrySetResult(new PromptResult(
                args.Result == CustomMessageBoxResult.LeftButton,
                isSecure ? password.Password : txt.Text.Trim()
            ));
            //this.Dispatch(prompt.Show);
            return this.tcs.Task;
        }


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
    }
}