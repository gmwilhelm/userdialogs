using System;
using System.Threading;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;


namespace Acr.UserDialogs {

    public class PromptDialogImpl : PromptDialog {
        TaskCompletionSource<PromptResult> tcs;


        public override Task<PromptResult> Request(CancellationToken? cancelToken) {
            var dialog = new ContentDialog { Title = this.Title };
            var txt = new TextBox {
                PlaceholderText = this.PlaceholderText,
                Text = this.Text ?? String.Empty
            };
            var stack = new StackPanel {
                Children = {
                    new TextBlock { Text = this.Message },
                    txt
                }
            };
            dialog.Content = stack;

            dialog.PrimaryButtonText = this.OkText;
            dialog.PrimaryButtonCommand = new Command(() => {
                this.tcs.TrySetResult(new PromptResult(true, txt.Text.Trim()));
                dialog.Hide();
            });

            if (this.IsCancellable) {
                dialog.SecondaryButtonText = this.CancelText;
                dialog.SecondaryButtonCommand = new Command(() => {
                    this.tcs.TrySetResult(new PromptResult(false, txt.Text.Trim()));
                    dialog.Hide();
                });
            }
            //this.Dispatch(() => dialog.ShowAsync());

            return this.tcs.Task;
        }
    }
}