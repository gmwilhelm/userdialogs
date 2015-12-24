using System;
using Android.Text;
using Android.Text.Method;
using Android.Views;
using Android.Widget;


namespace Acr.UserDialogs {

    public static class Extensions {

        public static AndroidHUD.MaskType ToNative(this MaskType maskType) {
            switch (maskType) {
                case MaskType.Black :
                    return AndroidHUD.MaskType.Black;

                case MaskType.Clear :
                    return AndroidHUD.MaskType.Clear;

                case MaskType.Gradient :
                    Console.WriteLine("Warning - Gradient mask type is not supported on android");
                    return AndroidHUD.MaskType.Black;

                case MaskType.None :
                    return AndroidHUD.MaskType.None;

                default:
                    throw new ArgumentException("Invalid Mask Type");
            }
        }


        public static TextView SetInputType(this TextView txt, InputType inputType) {
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
            return txt;
        }


#if APPCOMPAT
        public static Android.Support.V7.App.AlertDialog ShowExt(this Android.Support.V7.App.AlertDialog.Builder builder) {
            var dialog = builder.Create();
            dialog.Window.SetSoftInputMode(SoftInput.StateVisible);
            dialog.Show();
            return dialog;
        }

#else
        public static Android.App.AlertDialog ShowExt(this Android.App.AlertDialog.Builder builder) {
            var dialog = builder.Create();
            dialog.Window.SetSoftInputMode(SoftInput.StateVisible);
            dialog.Show();
            return dialog;
        }
#endif
    }
}