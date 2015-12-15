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
			if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
				this.ShowIOS8Prompt(config);
            else
				this.ShowIOS7Prompt(config);


        protected virtual void SetInputType(UITextField txt, InputType inputType) {
            switch (inputType) {
                case InputType.DecimalNumber:
                    txt.KeyboardType = UIKeyboardType.DecimalPad;
                    break;

                case InputType.Email  :
                    txt.KeyboardType = UIKeyboardType.EmailAddress;
                    break;

				case InputType.Name:
					break;

                case InputType.Number:
                    txt.KeyboardType = UIKeyboardType.NumberPad;
                    break;

                case InputType.NumericPassword:
                    txt.SecureTextEntry = true;
                    txt.KeyboardType = UIKeyboardType.NumberPad;
                    break;

                case InputType.Password:
                    txt.SecureTextEntry = true;
                    break;

				case InputType.Phone:
					txt.KeyboardType = UIKeyboardType.PhonePad;
					break;

				case InputType.Url:
					txt.KeyboardType = UIKeyboardType.Url;
					break;
            }
        }



protected virtual void ShowIOS7Prompt(PromptConfig config) {
			var result = new PromptResult();
			var isPassword = (config.InputType == InputType.Password || config.InputType == InputType.NumericPassword);
			var cancelText = config.IsCancellable ? config.CancelText : null;

			var dlg = new UIAlertView(config.Title ?? String.Empty, config.Message, null, cancelText, config.OkText) {
				AlertViewStyle = isPassword
					? UIAlertViewStyle.SecureTextInput
					: UIAlertViewStyle.PlainTextInput
			};
			var txt = dlg.GetTextField(0);
			this.SetInputType(txt, config.InputType);
			txt.Placeholder = config.Placeholder;
			if (config.Text != null)
				txt.Text = config.Text;

			dlg.Clicked += (s, e) => {
				result.Ok = ((int)dlg.CancelButtonIndex != (int)e.ButtonIndex);
				result.Text = txt.Text.Trim();
				config.OnResult(result);
			};
            this.Present(dlg);
		}


		protected virtual void ShowIOS8Prompt(PromptConfig config) {
			var result = new PromptResult();
			var dlg = UIAlertController.Create(config.Title ?? String.Empty, config.Message, UIAlertControllerStyle.Alert);
			UITextField txt = null;

			if (config.IsCancellable) {
				dlg.AddAction(UIAlertAction.Create(config.CancelText, UIAlertActionStyle.Cancel, x => {
					result.Ok = false;
					result.Text = txt.Text.Trim();
					config.OnResult(result);
				}));
			}
			dlg.AddAction(UIAlertAction.Create(config.OkText, UIAlertActionStyle.Default, x => {
				result.Ok = true;
				result.Text = txt.Text.Trim();
				config.OnResult(result);
			}));
			dlg.AddTextField(x => {
				this.SetInputType(x, config.InputType);
				x.Placeholder = config.Placeholder ?? String.Empty;
				if (config.Text != null)
					x.Text = config.Text;

				txt = x;
			});
			this.Present(dlg);
		}
*/