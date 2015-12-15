using System;
using System.Threading.Tasks;
using UIKit;


namespace Acr.UserDialogs {

    public class PromptDialogImpl : PromptDialog {
        readonly AlertDialogManager<PromptResult> manager = new AlertDialogManager<PromptResult>();


        public override async Task<PromptResult> Request() {
            this.manager.AssertFree();

			if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
				this.Ver8();
            else
				this.Ver7();

            var result = await this.manager.Tcs.Task;
            return result;
        }


        public override void Cancel() {
            base.Cancel();
            this.manager.Free();
        }


        protected virtual void Ver8() {
            var dlg = UIAlertController.Create(this.Title ?? String.Empty, this.Message, UIAlertControllerStyle.Alert);
            UITextField txt = null;

            if (this.IsCancellable) {
                dlg.AddAction(UIAlertAction.Create(this.CancelText, UIAlertActionStyle.Cancel, x =>
                    this.manager.Tcs.TrySetResult(new PromptResult(false, txt.Text.Trim()))
                ));
            }
            dlg.AddAction(UIAlertAction.Create(this.OkText, UIAlertActionStyle.Default, x => this.manager.Tcs.TrySetResult(new PromptResult(true, txt.Text.Trim()))));
            dlg.AddTextField(x => {
                this.SetInputType(x, this.InputType);
                x.Placeholder = this.PlaceholderText ?? String.Empty;
                if (this.Text != null)
                    x.Text = this.Text;

                txt = x;
            });
            //this.Present(dlg);
        }


        protected virtual void Ver7() {
            var isPassword = this.InputType == InputType.Password || this.InputType == InputType.NumericPassword;
            var cancelText = this.IsCancellable ? this.CancelText : null;

            var dlg = new UIAlertView(this.Title ?? String.Empty, this.Message, null, cancelText, this.OkText) {
                AlertViewStyle = isPassword
                    ? UIAlertViewStyle.SecureTextInput
                    : UIAlertViewStyle.PlainTextInput
            };
            var txt = dlg.GetTextField(0);
            this.SetInputType(txt, this.InputType);
            txt.Placeholder = this.PlaceholderText;
            if (this.Text != null)
                txt.Text = this.Text;

            dlg.Clicked += (s, e) => {
                var ok = (int)dlg.CancelButtonIndex != (int)e.ButtonIndex;
                this.manager.Tcs.TrySetResult(new PromptResult(ok, txt.Text.Trim()));
            };
            //         this.Present(dlg);
        }


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
    }
}