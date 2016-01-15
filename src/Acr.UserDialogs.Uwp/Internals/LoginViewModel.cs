using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;


namespace Acr.UserDialogs {

    public class LoginViewModel : INotifyPropertyChanged {

        public ICommand Login { get; set; }
        public ICommand Cancel { get; set; }

        public string UserNameText { get; set; }
        public string UserNamePlaceholder { get; set; }
        public string PasswordText { get; set; }
        public string PasswordPlaceholder { get; set; }

        string userName;
        public string UserName {
            get { return this.userName; }
            set { this.SetProperty(ref this.userName, value); }
        }


        string password;
        public string Password {
            get { return this.password; }
            set { this.SetProperty(ref this.password, value); }
        }


        public string CancelText { get; set; }
        public string LoginText { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual bool SetProperty<T>(ref T property, T value, [CallerMemberName] string propertyName = null) {
            if (Object.Equals(property, value))
                return false;

            property = value;
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            return true;
        }
    }
}
