﻿using System;
using System.Collections.Generic;
using Splat;


namespace Acr.UserDialogs {

    public abstract class AbstractActionSheetDialog : AbstractDialog, IActionSheetDialog {

        public abstract void Show();

        public virtual string Title { get; set; }
        public virtual ActionOption CancelOption { get; set; }
        public virtual ActionOption DestructiveOption { get; set; }
        public virtual IList<ActionOption> Options { get; set; } = new List<ActionOption>();
        public virtual IBitmap ItemIcon { get; set; }


        public virtual IActionSheetDialog SetTitle(string title) {
            this.Title = title;
            return this;
        }


		public virtual IActionSheetDialog SetCancelOption(string text = null, Action action = null) {
			this.CancelOption = new ActionOption(text ?? DefaultCancelText, action);
			return this;
		}


		public virtual IActionSheetDialog SetDestructiveOption(string text = null, Action action = null) {
			this.DestructiveOption = new ActionOption(text ?? DefaultDestructiveText, action);
			return this;
		}


        public virtual IActionSheetDialog Add(string text, Action action = null, IBitmap icon = null) {
            this.Options.Add(new ActionOption(text, action, icon));
            return this;
        }


        public static string DefaultCancelText { get; set; } = "Cancel";
        public static string DefaultDestructiveText { get; set; } = "Remove";
        public static IBitmap DefaultItemIcon { get; set; }
    }
}