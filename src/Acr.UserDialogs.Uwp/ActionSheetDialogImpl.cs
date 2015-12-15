using System;


namespace Acr.UserDialogs {

    public class ActionSheetDialogImpl : ActionSheetDialog {

        public override void Show() {
            throw new NotImplementedException();
        }
    }
}
/*
            var dlg = new ActionSheetContentDialog();

            var vm = new ActionSheetViewModel {
                Title = config.Title,
                Cancel = new ActionSheetOptionViewModel(config.Cancel != null,config.Cancel?.Text, () => {
                    dlg.Hide();
                    config.Cancel?.Action?.Invoke();
                }),

                Destructive = new ActionSheetOptionViewModel(config.Destructive != null, config.Destructive?.Text, () => {
                    dlg.Hide();
                    config.Destructive?.Action?.Invoke();
                }),

                Options = config
                    .Options
                    .Select(x => new ActionSheetOptionViewModel(true, x.Text, () => {
                        dlg.Hide();
                        x.Action?.Invoke();
                    }, x.ItemIcon != null ? x.ItemIcon : config.ItemIcon))
                    .ToList()
            };

            dlg.DataContext = vm;
            this.Dispatch(() => dlg.ShowAsync());
*/