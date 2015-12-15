using System;


namespace Acr.UserDialogs {

    public abstract class Dialog : IDisposable {


        public virtual void Cancel() {
            this.IsVisible = false;
        }


        public virtual bool IsVisible { get; protected set; }


        public void Dispose() {
            this.Cancel();
            this.Dispose(true);
        }


        protected virtual void Dispose(bool disposing) {
            if (!disposing)
                return;

            GC.SuppressFinalize(this);
        }
    }
}
