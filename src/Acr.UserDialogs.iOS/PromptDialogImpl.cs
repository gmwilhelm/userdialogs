﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Acr.Support.iOS;
using UIKit;


namespace Acr.UserDialogs {

    public class PromptDialogImpl : AbstractPromptDialog {
        readonly AlertDialogManager<PromptResult> manager = new AlertDialogManager<PromptResult>();


        public override async Task<PromptResult> Request(CancellationToken? cancelToken) {
            cancelToken?.Register(this.Cancel);
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
            UITextField txt = null;

            var dlg = UIAlertController.Create(
                this.Title,
                this.Message,
                UIAlertControllerStyle.Alert
            );
			this.manager.Set(dlg);

            if (this.IsCancellable)
                dlg.AddAction(UIAlertAction.Create(this.CancelText, UIAlertActionStyle.Cancel, x =>
                    this.manager.Tcs.TrySetResult(new PromptResult(false, txt.Text))
                ));

            dlg.AddAction(UIAlertAction.Create(
                this.OkText,
                UIAlertActionStyle.Default,
                x => this.manager.Tcs.TrySetResult(new PromptResult(true, txt.Text))
            ));
            dlg.AddTextField(x => {
                this.SetInputType(x, this.InputType);
                x.Placeholder = this.PlaceholderText ?? String.Empty;
                if (this.Text != null)
                    x.Text = this.Text;

                txt = x;
            });
            UIApplication.SharedApplication.Present(dlg);
        }


        protected virtual void Ver7() {
            var isPassword = this.InputType == InputType.Password || this.InputType == InputType.NumericPassword;
            var cancelText = this.IsCancellable ? this.CancelText : null;

            var dlg = new UIAlertView(this.Title ?? String.Empty, this.Message ?? String.Empty, null, cancelText, this.OkText) {
                AlertViewStyle = isPassword
                    ? UIAlertViewStyle.SecureTextInput
                    : UIAlertViewStyle.PlainTextInput
            };
			this.manager.Set(dlg);

            var txt = dlg.GetTextField(0);
            this.SetInputType(txt, this.InputType);
            txt.Placeholder = this.PlaceholderText;
            if (this.Text != null)
                txt.Text = this.Text;

            dlg.Clicked += (s, e) => {
                var ok = (int)dlg.CancelButtonIndex != (int)e.ButtonIndex;
                this.manager.Tcs.TrySetResult(new PromptResult(ok, txt.Text));
            };
            UIApplication.SharedApplication.InvokeOnMainThread(dlg.Show);
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