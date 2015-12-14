using System;
using System.Collections.Generic;
using Splat;


namespace Acr.UserDialogs {

    public abstract class ActionSheetDialog : Dialog {

        protected ActionSheetDialog() {
            this.ItemIcon = DefaultItemIcon;
            this.Options = new List<ActionOption>();
        }


        public virtual string Title { get; set; }
        public virtual ActionOption Cancel { get; set; }
        public virtual ActionOption Destructive { get; set; }
        public virtual IList<ActionOption> Options { get; set; }
        public virtual IBitmap ItemIcon { get; set; }


        public static string DefaultCancelText { get; set; } = "Cancel";
        public static string DefaultDestructiveText { get; set; } = "Remove";
        public static IBitmap DefaultItemIcon { get; set; }
    }
}
/*




        public ActionSheetConfig SetTitle(string title) {
            this.Title = title;
            return this;
        }


		public ActionSheetConfig SetCancel(string text = null, Action action = null) {
			this.Cancel = new ActionOption(text ?? DefaultCancelText, action);
			return this;
		}


		public ActionSheetConfig SetDestructive(string text = null, Action action = null) {
			this.Destructive = new ActionOption(text ?? DefaultDestructiveText, action);
			return this;
		}


        public ActionSheetConfig Add(string text, Action action = null, IBitmap icon = null) {
            this.Options.Add(new ActionOption(text, action, icon));
            return this;
        }
*/
