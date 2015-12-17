using System;
using Splat;


namespace Acr.UserDialogs {

    public class UserDialogsImpl : AbstractUserDialogs {




        //protected virtual void Dispatch(Action action) {
        //    Deployment.Current.Dispatcher.BeginInvoke(action);
        //}
        public override ActionSheetDialog ActionSheetBuilder() {
            return new ActionSheetDialogImpl();
        }


        public override AlertDialog AlertBuilder() {
            return new AlertDialogImpl();
        }


        public override ConfirmDialog ConfirmBuilder() {
            return new ConfirmDialogImpl();
        }


        public override LoginDialog LoginBuilder() {
            return new LoginDialogImpl();
        }


        public override ProgressDialog ProgressBuilder() {
            return new ProgressDialogImpl();
        }


        public override PromptDialog PromptBuilder() {
            return new PromptDialogImpl();
        }


        public override ToastDialog ToastBuilder() {
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