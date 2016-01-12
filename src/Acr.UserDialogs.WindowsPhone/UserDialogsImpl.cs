using System;
using Splat;


namespace Acr.UserDialogs {

    public class UserDialogsImpl : AbstractUserDialogs {




        //protected virtual void Dispatch(Action action) {
        //    Deployment.Current.Dispatcher.BeginInvoke(action);
        //}
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
            throw new NotImplementedException();
        }


        public override void ShowSuccess(string message, int timeoutMillis) {
            throw new NotImplementedException();
        }


        public override void ShowError(string message, int timeoutMillis) {
            throw new NotImplementedException();
        }
    }
}