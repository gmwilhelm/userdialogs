using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Acr.UserDialogs
{
    class ProgressDialogImpl : AbstractProgressDialog, INotifyPropertyChanged
    {
        readonly ProgressContentDialog dialog;


        public ProgressDialogImpl()
        {
            this.dialog = new ProgressContentDialog { DataContext = this };
        }


        public override void Show()
        {
            if (this.IsVisible)
                return;

            this.IsVisible = true;
            this.Dispatch(() => this.dialog.ShowAsync());
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            this.Hide();
        }


        public void Hide()
        {
            this.IsVisible = false;
            this.dialog.Hide();
        }



        void Change([CallerMemberName] string property = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }


        public event PropertyChangedEventHandler PropertyChanged;


        public override int PercentComplete
        {
            get
            {
                return base.PercentComplete;
            }

            set
            {
                base.PercentComplete = value;
                this.Change();
            }
        }

    }
}
