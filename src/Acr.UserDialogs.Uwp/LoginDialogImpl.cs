using System;
using System.Threading;
using System.Threading.Tasks;


namespace Acr.UserDialogs {

    public class LoginDialogImpl : LoginDialog {
        TaskCompletionSource<LoginResult> tcs;


        public override Task<LoginResult> Request(CancellationToken? cancelToken = null) {
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
            //this.Dispatch(() => dlg.ShowAsync());

            return this.tcs.Task;
        }
    }
}