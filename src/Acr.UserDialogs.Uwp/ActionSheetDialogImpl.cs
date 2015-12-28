using System;
using System.Linq;
using Windows.UI.Core;


namespace Acr.UserDialogs {

    public class ActionSheetDialogImpl : ActionSheetDialog {
        ActionSheetContentDialog dialog;


        public override void Cancel() {
            base.Cancel();
            this.dialog.Hide();
            this.dialog = null;
        }


        public override void Show() {
            this.dialog = new ActionSheetContentDialog();
            var vm = new ActionSheetViewModel {
                Title = this.Title,
                Cancel = new ActionSheetOptionViewModel(this.CancelOption != null, this.CancelOption?.Text, () => {
                    this.dialog.Hide();
                    this.CancelOption?.Action?.Invoke();
                }),

                Destructive = new ActionSheetOptionViewModel(this.DestructiveOption != null, this.DestructiveOption?.Text, () => {
                    this.dialog.Hide();
                    this.DestructiveOption?.Action?.Invoke();
                }),

                Options = this
                    .Options
                    .Select(x => new ActionSheetOptionViewModel(true, x.Text, () => {
                        this.dialog.Hide();
                        x.Action?.Invoke();
                    }, x.ItemIcon ?? this.ItemIcon))
                    .ToList()
            };

            this.dialog.DataContext = vm;
            this.Dispatch(() => this.dialog.ShowAsync());
        }
    }
}