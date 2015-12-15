using System;
using System.Linq;
using Acr.Support.iOS;
using Foundation;
using Splat;
using UIKit;


namespace Acr.UserDialogs {

    public class ActionSheetDialogImpl : ActionSheetDialog {


        public override void Show() {
            if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
                this.Ver8();
            else
                this.Ver7();
        }


		protected virtual void Ver7() {
			var view = UIApplication.SharedApplication.GetTopView();
			var action = new UIActionSheet(this.Title);
			this.Options
                .ToList()
                .ForEach(x => action.AddButton(x.Text));
			var index = this.Options.Count - 1;

			if (this.DestructiveOption != null) {
				index++;
				action.AddButton(this.DestructiveOption.Text);
				action.DestructiveButtonIndex = index;
			}

			if (this.CancelOption != null) {
				index++;
				action.AddButton(this.CancelOption.Text);
				action.CancelButtonIndex = index;
			}

			action.Dismissed += (sender, btn) => {
				if (btn.ButtonIndex == action.DestructiveButtonIndex)
					this.DestructiveOption.Action?.Invoke();

				else if (btn.ButtonIndex == action.CancelButtonIndex)
					this.CancelOption.Action?.Invoke();

				else if (btn.ButtonIndex > -1)
					this.Options[(int)btn.ButtonIndex].Action?.Invoke();
			};
			UIApplication.SharedApplication.InvokeOnMainThread(() => action.ShowInView(view));
		}


		protected virtual void Ver8() {
			var sheet = UIAlertController.Create(this.Title, null, UIAlertControllerStyle.ActionSheet);
			this
				.Options
				.ToList()
				.ForEach(x => this.AddActionSheetOption(x, sheet, UIAlertActionStyle.Default, this.ItemIcon));

			if (this.DestructiveOption != null)
				this.AddActionSheetOption(this.DestructiveOption, sheet, UIAlertActionStyle.Destructive);

			if (this.CancelOption != null)
				this.AddActionSheetOption(this.CancelOption, sheet, UIAlertActionStyle.Cancel);

			//this.Present(sheet);
		}


		protected virtual void AddActionSheetOption(ActionOption opt, UIAlertController controller, UIAlertActionStyle style, IBitmap image = null) {
            var alertAction = UIAlertAction.Create(opt.Text, style, x => opt.Action?.Invoke());

            if (this.ItemIcon == null && image != null)
                opt.ItemIcon = image;

            if (opt.ItemIcon != null)
                alertAction.SetValueForKey(opt.ItemIcon.ToNative(), new NSString("image"));

            controller.AddAction(alertAction);
		}
    }
}