using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Phone.Controls;


namespace Acr.UserDialogs {

    public class ActionSheetDialogImpl : ActionSheetDialog {

        public override void Show() {
            var sheet = new CustomMessageBox {
                Caption = this.Title
            };
            if (this.CancelOption != null) {
                sheet.IsRightButtonEnabled = true;
                sheet.RightButtonContent = this.CreateButton(this.CancelOption.Text, () => {
                    sheet.Dismiss();
                    this.CancelOption.Action?.Invoke();
                });
            }
            if (this.DestructiveOption != null) {
                sheet.IsLeftButtonEnabled = true;
                sheet.LeftButtonContent = this.CreateButton(this.DestructiveOption.Text, () => {
                    sheet.Dismiss();
                    this.DestructiveOption.Action?.Invoke();
                });
            }

            var list = new ListBox {
                FontSize = 36,
                Margin = new Thickness(12.0),
                SelectionMode = SelectionMode.Single,
                ItemsSource = this
                    .Options
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
            Deployment.Current.Dispatcher.BeginInvoke(sheet.Show);
        }


        protected virtual Button CreateButton(string text, Action action) {
            var btn = new Button { Content = text };
            btn.Click += (sender, args) => action();
            return btn;
        }
    }
}