using System;
using System.Threading;
using System.Threading.Tasks;


namespace Acr.UserDialogs {

    public class PromptDialogImpl : PromptDialog {

        public override Task<PromptResult> Request(CancellationToken? cancelToken) {
            throw new NotImplementedException();
        }
    }
}
/*
            var dialog = new ContentDialog { Title = config.Title };
            var txt = new TextBox {
                PlaceholderText = config.Placeholder,
                Text = config.Text ?? String.Empty
            };
            var stack = new StackPanel {
                Children = {
                    new TextBlock { Text = config.Message },
                    txt
                }
            };
            dialog.Content = stack;

            dialog.PrimaryButtonText = config.OkText;
            dialog.PrimaryButtonCommand = new Command(() => {
                config.OnResult?.Invoke(new PromptResult {
                    Ok = true,
                    Text = txt.Text.Trim()
                });
                dialog.Hide();
            });

            if (config.IsCancellable) {
                dialog.SecondaryButtonText = config.CancelText;
                dialog.SecondaryButtonCommand = new Command(() => {
                    config.OnResult?.Invoke(new PromptResult {
                        Ok = false,
                        Text = txt.Text.Trim()
                    });
                    dialog.Hide();
                });
            }
            this.Dispatch(() => dialog.ShowAsync());
*/