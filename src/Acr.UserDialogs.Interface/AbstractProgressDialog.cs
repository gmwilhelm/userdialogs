using System;


namespace Acr.UserDialogs {

	public abstract class AbstractProgressDialog : AbstractDialog, IProgressDialog {
                // if title or percent complete changes we need to update

        //string title;
        //public virtual string Title {
        //    get { return this.title; }
        //    set {
        //        if (this.title == value)
        //            return;

        //        this.title = value;
        //        this.Refresh();
        //    }
        //}


        string title;
        public virtual string Title {
            get;
            set;
        }


        int percentComplete;
	    public virtual int PercentComplete {
	        get { return this.percentComplete; }
	        set {
                if (this.percentComplete == value)
                    return;

                if (value > 100)
                    this.percentComplete = 100;
                else if (value < 0)
                    this.percentComplete = 0;
                else
                    this.percentComplete = value;
            }
	    }
		public virtual bool IsDeterministic { get; set; }
        public virtual MaskType MaskType { get; set; } = MaskType.Black;
        public virtual ActionOption CancelOption { get; set; }


        public abstract void Show();


        public virtual IProgressDialog SetCancel(string cancelText = null, Action onCancel = null) {
            this.CancelOption = new ActionOption(cancelText ?? DefaultCancelText, onCancel);
            return this;
        }


        public virtual IProgressDialog SetTitle(string title) {
            this.Title = title;
            return this;
        }


        public virtual IProgressDialog SetMaskType(MaskType maskType) {
            this.MaskType = maskType;
            return this;
        }


        public virtual IProgressDialog SetIsDeterministic(bool isDeterministic) {
            this.IsDeterministic = isDeterministic;
            return this;
        }


        public static string DefaultCancelText { get; set; } = "Cancel";
        public static string DefaultTitle { get; set; } = "Loading";
        public static MaskType DefaultMaskType { get; set; } = MaskType.Black;
	}
}
