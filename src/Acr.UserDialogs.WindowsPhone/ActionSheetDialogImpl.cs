using System;


namespace Acr.UserDialogs {

    public class ActionSheetDialogImpl : ActionSheetDialog {

        public override void Show() {
            throw new NotImplementedException();
        }
    }
}
/*

            var sheet = new CustomMessageBox {
                Caption = config.Title
            };
            if (config.Cancel != null) {
                sheet.IsRightButtonEnabled = true;
                sheet.RightButtonContent = this.CreateButton(config.Cancel.Text, () => {
                    sheet.Dismiss();
                    config.Cancel.Action?.Invoke();
                });
            }
            if (config.Destructive != null) {
                sheet.IsLeftButtonEnabled = true;
                sheet.LeftButtonContent = this.CreateButton(config.Destructive.Text, () => {
                    sheet.Dismiss();
                    config.Destructive.Action?.Invoke();
                });
            }

            var list = new ListBox {
                FontSize = 36,
                Margin = new Thickness(12.0),
                SelectionMode = SelectionMode.Single,
                ItemsSource = config.Options
                    .Select(x => new TextBlock {
                        Text = x.Text,
                        Margin = new Thickness(0.0, 12.0, 0.0, 12.0),
                        DataContext = x
                    })
            };
            list.SelectionChanged += (sender, args) => sheet.Dismiss();
            sheet.Content = new ScrollViewer {
                Content = list
            };
            sheet.Dismissed += (sender, args) => {
                var txt = list.SelectedValue as TextBlock;
                if (txt == null)
                    return;

                var action = txt.DataContext as ActionOption;
                action?.Action?.Invoke();
            };
            this.Dispatch(sheet.Show);
*/