using System;
using System.Threading.Tasks;
using UIKit;


namespace Acr.UserDialogs {

    public class AlertDialogManager<T> {

        public TaskCompletionSource<T> Tcs { get; private set; }
        public UIAlertView View { get; private set; }
        public UIAlertController Controller { get; private set; }
        public bool IsLive { get; private set; }


        public void AssertFree() {
            if (this.IsLive)
                throw new ArgumentException("You already have a visible dialog open for this builder");
        }


        public void Free() {
            if (!this.IsLive)
                return;

            if (!this.Tcs.Task.IsCompleted)
                this.Tcs.TrySetCanceled();

            this.Tcs = new TaskCompletionSource<T>();
            this.View?.Dispose();
            this.View = null;

            this.Controller?.Dispose();
            this.Controller = null;
            this.IsLive = false;
        }


        public void Set(UIAlertView view) {
            this.AssertFree();

            this.View = view;
            this.Tcs = new TaskCompletionSource<T>();
            this.IsLive = true;
        }


        public void Set(UIAlertController ctrl) {
            this.AssertFree();

            this.Controller = ctrl;
            this.Tcs = new TaskCompletionSource<T>();
            this.IsLive = true;
        }
    }
}
