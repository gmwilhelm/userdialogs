using System;


namespace Acr.UserDialogs {

    public class ActionSheetDialogImpl : ActionSheetDialog {


        public override void Show() {
            throw new NotImplementedException();
        }
    }
}
/*
			if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
				this.ShowIOS8ActionSheet(config);
			else
				this.ShowIOS7ActionSheet(config);


		protected virtual void AddActionSheetOption(ActionOption opt, UIAlertController controller, UIAlertActionStyle style, IBitmap image = null) {
            var alertAction = UIAlertAction.Create(opt.Text, style, x => opt.Action?.Invoke());

            if (opt.ItemIcon == null && image != null)
                opt.ItemIcon = image;

            if (opt.ItemIcon != null)
                alertAction.SetValueForKey(opt.ItemIcon.ToNative(), new Foundation.NSString("image"));

            controller.AddAction(alertAction);
		}


		protected virtual void ShowIOS7ActionSheet(ActionSheetConfig config) {
			var view = UIApplication.SharedApplication.GetTopView();
			var action = new UIActionSheet(config.Title);
			config.Options.ToList().ForEach(x => action.AddButton(x.Text));
			var index = config.Options.Count - 1;

			if (config.Destructive != null) {
				index++;
				action.AddButton(config.Destructive.Text);
				action.DestructiveButtonIndex = index;
			}

			if (config.Cancel != null) {
				index++;
				action.AddButton(config.Cancel.Text);
				action.CancelButtonIndex = index;
			}

			action.Dismissed += (sender, btn) => {
				if (btn.ButtonIndex == action.DestructiveButtonIndex)
					config.Destructive.Action?.Invoke();

				else if (btn.ButtonIndex == action.CancelButtonIndex)
					config.Cancel.Action?.Invoke();

				else if (btn.ButtonIndex > -1)
					config.Options[(int)btn.ButtonIndex].Action?.Invoke();
			};
			UIApplication.SharedApplication.InvokeOnMainThread(() => action.ShowInView(view));
		}


		protected virtual void ShowIOS8ActionSheet(ActionSheetConfig config) {
			var sheet = UIAlertController.Create(config.Title, null, UIAlertControllerStyle.ActionSheet);
			config
				.Options
				.ToList()
				.ForEach(x => this.AddActionSheetOption(x, sheet, UIAlertActionStyle.Default, config.ItemIcon));

			if (config.Destructive != null)
				this.AddActionSheetOption(config.Destructive, sheet, UIAlertActionStyle.Destructive);

			if (config.Cancel != null)
				this.AddActionSheetOption(config.Cancel, sheet, UIAlertActionStyle.Cancel);

			this.Present(sheet);
		}
*/