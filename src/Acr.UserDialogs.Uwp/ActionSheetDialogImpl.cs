using System;
using System.Linq;


namespace Acr.UserDialogs {

    public class ActionSheetDialogImpl : ActionSheetDialog {

        public override void Show() {
             var dlg = new ActionSheetContentDialog();

            var vm = new ActionSheetViewModel {
                Title = this.Title,
                Cancel = new ActionSheetOptionViewModel(this.CancelOption != null, this.CancelOption?.Text, () => {
                    dlg.Hide();
                    this.CancelOption?.Action?.Invoke();
                }),

                Destructive = new ActionSheetOptionViewModel(this.DestructiveOption != null, this.DestructiveOption?.Text, () => {
                    dlg.Hide();
                    this.DestructiveOption?.Action?.Invoke();
                }),

                Options = this
                    .Options
                    .Select(x => new ActionSheetOptionViewModel(true, x.Text, () => {
                        dlg.Hide();
                        x.Action?.Invoke();
                    }, x.ItemIcon ?? this.ItemIcon))
                    .ToList()
            };

            dlg.DataContext = vm;
            //this.Dispatch(() => dlg.ShowAsync());
        }
    }
}