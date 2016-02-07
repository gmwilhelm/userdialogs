using System;
using Android.App;
using Utils = Acr.Support.Android.Extensions;
using AndroidHUD;

namespace Acr.UserDialogs {

    public class ProgressDialogImpl : AbstractProgressDialog {
        readonly Activity activity;


        public ProgressDialogImpl(Activity activity) {
            this.activity = activity;
            this.MaskType = MaskType.Black;
        }


        public override void Show() {
            //throw new NotImplementedException();
            this.Refresh();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            this.IsVisible = false;
            Utils.RequestMainThread(() => AndHUD.Shared.Dismiss(this.activity));
        }

   
        protected virtual void Refresh()
        {
            //if (!this.IsVisible)
            //    return;

            var txt = this.Title;
            int p = -1;
            if (this.IsDeterministic) {
                p = this.PercentComplete;
                if (!String.IsNullOrWhiteSpace(txt))
                    txt += "\n";

                txt += p + "%\n";
            }

            
            //if (this.cancelAction != null)
            //    txt += "\n" + this.cancelText;
                

            Utils.RequestMainThread(() => AndHUD.Shared.Show(
                this.activity,
                txt,
                p,  
                this.MaskType.ToNative(),
                null,
                null //this.OnCancelClick
            ));
        }


        //      #region IProgressDialog Members

        //      string title;
        //      public virtual string Title {
        //          get { return this.title; }
        //          set {
        //              if (this.title == value)
        //                  return;

        //              this.title = value;
        //              this.Refresh();
        //          }
        //      }


        //      public MaskType MaskType { get; set; }


        int percentComplete;

        public override int PercentComplete
        {
            get
            {
                return this.percentComplete;
            }

            set
            {
                if (this.percentComplete == value)
                    return;

                if (value > 100)
                    this.percentComplete = 100;
                else if (value < 0)
                    this.percentComplete = 0;
                else
                    this.percentComplete = value;

                this.Refresh();
            }
        }

        //      int percentComplete;
        //      public virtual int PercentComplete {
        //          get { return this.percentComplete; }
        //          set {
        //              if (this.percentComplete == value)
        //                  return;

        //              if (value > 100)
        //                  this.percentComplete = 100;
        //              else if (value < 0)
        //                  this.percentComplete = 0;
        //              else
        //                  this.percentComplete = value;

        //              this.Refresh();
        //          }
        //      }


        //      public virtual bool IsDeterministic { get; set; }
        //      public virtual bool IsShowing { get; private set; }


        //      Action cancelAction;
        //      string cancelText;
        //      public virtual void SetCancel(Action onCancel, string cancel) {
        //          this.cancelAction = onCancel;
        //          this.cancelText = cancel;
        //      }


        //      public virtual void Show() {
        //          if (this.IsShowing)
        //              return;

        //          this.IsShowing = true;
        //          this.Refresh();
        //      }


        //      public virtual void Hide() {
        //          this.IsShowing = false;
        //	Utils.RequestMainThread(() => AndHUD.Shared.Dismiss(this.activity));
        //      }

        //      #endregion

        //      #region IDisposable Members

        //      public virtual void Dispose() {
        //          this.Hide();
        //      }

        //      #endregion

        //      #region Internals

        //      protected virtual void Refresh() {
        //          if (!this.IsShowing)
        //              return;

        //          var p = -1;
        //          var txt = this.Title;
        //          if (this.IsDeterministic) {
        //              p = this.PercentComplete;
        //              if (!String.IsNullOrWhiteSpace(txt))
        //                  txt += "\n";

        //              txt += p + "%\n";
        //          }

        //          if (this.cancelAction != null)
        //              txt += "\n" + this.cancelText;

        //          Utils.RequestMainThread(() => AndHUD.Shared.Show(
        //		this.activity,
        //              txt,
        //              p,
        //              this.MaskType.ToNative(),
        //              null,
        //              this.OnCancelClick
        //          ));
        //      }


        //      private void OnCancelClick() {
        //          if (this.cancelAction == null)
        //              return;

        //          this.Hide();
        //          this.cancelAction();
        //      }

        //      #endregion
    }
}