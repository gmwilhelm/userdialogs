using System;
using UIKit;
using BigTed;
using Splat;


namespace Acr.UserDialogs {

    public class UserDialogsImpl : AbstractUserDialogs {

        public override IActionSheetDialog ActionSheetBuilder() {
            return new ActionSheetDialogImpl();
        }


        public override IAlertDialog AlertBuilder() {
            return new AlertDialogImpl();
        }


        public override IConfirmDialog ConfirmBuilder() {
            return new ConfirmDialogImpl();
        }


        public override ILoginDialog LoginBuilder() {
            return new LoginDialogImpl();
        }


        public override IProgressDialog ProgressBuilder() {
            return new ProgressDialogImpl();
        }


        public override IPromptDialog PromptBuilder() {
            return new PromptDialogImpl();
        }


        public override IToastDialog ToastBuilder() {
            return new ToastDialogImpl();
        }


        public override void ShowImage(IBitmap image, string message, int timeoutMillis) {
            UIApplication.SharedApplication.InvokeOnMainThread(() =>
                BTProgressHUD.ShowImage(image.ToNative(), message, timeoutMillis)
            );
        }


        public override void ShowError(string message, int timeoutMillis) {
            UIApplication.SharedApplication.InvokeOnMainThread(() =>
                BTProgressHUD.ShowErrorWithStatus(message, timeoutMillis)
            );
        }


        public override void ShowSuccess(string message, int timeoutMillis) {
            UIApplication.SharedApplication.InvokeOnMainThread(() =>
                BTProgressHUD.ShowSuccessWithStatus(message, timeoutMillis)
            );
        }
    }
}

        //public override void DateTimePrompt(DateTimePromptConfig config) {
        //    var sheet = new ActionSheetDatePicker {
        //        Title = config.Title,
        //        DoneText = config.OkText
        //    };

        //    switch (config.SelectionType) {
        //        case DateTimeSelectionType.Date:
        //            sheet.DatePicker.Mode = UIDatePickerMode.Date;
        //            break;

        //        case DateTimeSelectionType.Time:
        //            sheet.DatePicker.Mode = UIDatePickerMode.Time;
        //            break;

        //        case DateTimeSelectionType.DateTime:
        //            sheet.DatePicker.Mode = UIDatePickerMode.DateAndTime;
        //            break;
        //    }
        //    if (config.MinValue != null)
        //        sheet.DatePicker.MinimumDate = config.MinValue.Value;

        //    if (config.MaxValue != null)
        //        sheet.DatePicker.MaximumDate = config.MaxValue.Value;

        //    sheet.DateTimeSelected += (sender, args) => {
        //        // TODO: stop adjusting date/time
        //        config.OnResult(new DateTimePromptResult(sheet.DatePicker.Date));
        //    };

        //    var top = Utils.GetTopView();
        //    sheet.Show(top);
        //    //sheet.DatePicker.MinuteInterval
        //}


        //public override void DurationPrompt(DurationPromptConfig config) {
        //    var sheet = new ActionSheetDatePicker {
        //        Title = config.Title,
        //        DoneText = config.OkText
        //    };
        //    sheet.DatePicker.Mode = UIDatePickerMode.CountDownTimer;

        //    sheet.DateTimeSelected += (sender, args) => config.OnResult(new DurationPromptResult(args.TimeOfDay));

        //    var top = Utils.GetTopView();
        //    sheet.Show(top);
        //}
