using System;
using System.Threading;
using System.Threading.Tasks;


namespace Acr.UserDialogs {

    public class LoginDialogImpl : LoginDialog {

        public override Task<LoginResult> Request(CancellationToken? cancelToken = null) {
            throw new NotImplementedException();
        }
    }
}
/*
            var dlg = new LoginContentDialog();
            var vm = new LoginViewModel {
                LoginText = config.OkText,
                Title = config.Title,
                Message = config.Message,
                UserName = config.LoginValue,
                UserNamePlaceholder = config.LoginPlaceholder,
                PasswordPlaceholder = config.PasswordPlaceholder,
                CancelText = config.CancelText
            };
            vm.Login = new Command(() =>
                config.OnResult?.Invoke(new LoginResult(vm.UserName, vm.Password, true))
            );
            vm.Cancel = new Command(() =>
                config.OnResult?.Invoke(new LoginResult(vm.UserName, vm.Password, false))
            );
            dlg.DataContext = vm;
            this.Dispatch(() => dlg.ShowAsync());
*/