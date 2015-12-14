using System;


namespace Acr.UserDialogs {

	public abstract class ProgressDialog : Dialog {

        public virtual string Title { get; set; }
		public virtual int PercentComplete { get; set; }
		public virtual bool IsDeterministic { get; set; }
        public virtual MaskType MaskType { get; set; }
        public virtual ActionOption Cancel { get; set; }
    }
}
