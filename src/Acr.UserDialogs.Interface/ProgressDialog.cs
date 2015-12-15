using System;


namespace Acr.UserDialogs {

	public abstract class ProgressDialog : Dialog {

        public virtual string Title { get; set; }
		public virtual int PercentComplete { get; set; }
		public virtual bool IsDeterministic { get; set; }
        public virtual MaskType MaskType { get; set; }
        public virtual ActionOption CancelOption { get; set; }


        public virtual ProgressDialog SetCancel(string cancelText = null, Action onCancel = null) {
            this.CancelOption = new ActionOption(cancelText ?? DefaultCancelText, onCancel);
            return this;
        }


        public virtual ProgressDialog SetTitle(string title) {
            this.Title = title;
            return this;
        }


        public virtual ProgressDialog SetMaskType(MaskType maskType) {
            this.MaskType = maskType;
            return this;
        }


        public virtual ProgressDialog SetIsDeterministic(bool isDeterministic) {
            this.IsDeterministic = isDeterministic;
            return this;
        }


        public static string DefaultCancelText { get; set; } = "Cancel";
        public static string DefaultTitle { get; set; } = "Loading";
        public static MaskType DefaultMaskType { get; set; } = MaskType.Black;
    }
}
