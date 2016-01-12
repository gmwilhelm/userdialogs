using System;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;


namespace Acr.UserDialogs {

    public class LoginDialogImpl : AbstractLoginDialog {
        IAsyncOperation<ContentDialogResult> dialogCancel;
        TaskCompletionSource<LoginResult> tcs;


        public override void Cancel() {
            base.Cancel();
            this.dialogCancel?.Cancel();
            this.tcs?.TrySetCanceled();
        }


        public override Task<LoginResult> Request(CancellationToken? cancelToken = null) {
            cancelToken?.Register(this.Cancel);
            var dlg = new LoginContentDialog();

            var vm = new LoginViewModel {
                LoginText = this.OkText,
                Title = this.Title,
                Message = this.Message,
                UserName = this.LoginValue,
                UserNamePlaceholder = this.LoginPlaceholder,
                PasswordPlaceholder = this.PasswordPlaceholder,
                CancelText = this.CancelText
            };
            vm.Login = new Command(() =>
                this.tcs.TrySetResult(new LoginResult(vm.UserName, vm.Password, true))
            );
            vm.Cancel = new Command(() =>
                this.tcs.TrySetResult(new LoginResult(vm.UserName, vm.Password, false))
            );
            dlg.DataContext = vm;
            this.Dispatch(() => this.dialogCancel = dlg.ShowAsync());

            return this.tcs.Task;
        }
    }
}