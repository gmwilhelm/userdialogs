using System;
using System.Threading;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Xamarin.Forms;
using Splat;


namespace Samples {

    public class MainPage : TabbedPage {
		bool autoDismiss = false;
		IDialog dialog;



        public MainPage() {
			var btnAutoDismiss = new Button { Text = "Enable Auto-Dismiss" };
			btnAutoDismiss.Clicked += (sender, e) => {
				this.autoDismiss = !this.autoDismiss;
				btnAutoDismiss.Text = this.autoDismiss
					? "Disable Auto-Dismiss"
					: "Enable Auto-Dismiss";
			};
			Task.Run(async () => {
				while (true) {
					await Task.Delay(TimeSpan.FromSeconds(3));
					if (this.autoDismiss)
						this.dialog?.Cancel();
				}
			});


            Device.OnPlatform(() => {
                this.Padding = new Thickness(0, 30, 0, 0);
            });
            this.AddPage(
                "Standard Dialogs",
				btnAutoDismiss,
                Btn("Alert", () => this.Alert()),
                Btn("ActionSheet", () => this.ActionSheet()),
                Btn("ActionSheet (async)", () => this.ActionSheetAsync()),
                Btn("Confirm", () => this.Confirm()),
                Btn("Login", () => this.Login()),
	            Btn("Prompt", () => this.Prompt()),
				Btn("Prompt /w Text/No Cancel", () => this.PromptWithTextAndNoCancel()),
                Btn("Error", () => UserDialogs.Instance.ShowError("ERROR!")),
                Btn("Success", () => UserDialogs.Instance.ShowSuccess("SUCCESS!"))
            );

            this.AddPage(
                "Progress",
				Btn("Manual Loading", () => this.ManualLoading()),
	            Btn("Progress", () => this.Progress()),
	            Btn("Progress (No Cancel)", () => this.ProgressNoCancel()),
	            Btn("Loading (Black - Default)", () => this.Loading(MaskType.Black)),
                Btn("Loading (Clear)", () => this.Loading(MaskType.Clear)),
                Btn("Loading (Gradient iOS)", () => this.Loading(MaskType.Gradient)),
                Btn("Loading (None)", () => this.Loading(MaskType.Black)),
	            Btn("Loading (No Cancel)", () => this.LoadingNoCancel()),
                Btn("Loading to Success", () => this.LoadingToSuccess())
            );

            this.AddPage(
                "Toasts",
				Btn("Success", () => this.Toast(ToastEvent.Success)),
				Btn("Info", () => this.Toast(ToastEvent.Info)),
				Btn("Warning", () => this.Toast(ToastEvent.Warn)),
				Btn("Error", () => this.Toast(ToastEvent.Error))
            );

            this.AddPage(
                "Settings/Themes",
                Btn("Change Default Settings", () => {
                    // CANCEL
                    AbstractActionSheetDialog.DefaultCancelText = AbstractConfirmDialog.DefaultCancelText = AbstractLoginDialog.DefaultCancelText = AbstractPromptDialog.DefaultCancelText = AbstractProgressDialog.DefaultCancelText = "NO WAY";

                    // OK
                    AbstractAlertDialog.DefaultOkText = AbstractConfirmDialog.DefaultOkText = AbstractLoginDialog.DefaultOkText = AbstractPromptDialog.DefaultOkText = "Sure";

                    // CUSTOM
                    AbstractActionSheetDialog.DefaultDestructiveText = "BOOM!";
                    AbstractConfirmDialog.DefaultYes = "SIGN LIFE AWAY";
                    AbstractConfirmDialog.DefaultNo = "NO WAY";
                    AbstractLoginDialog.DefaultTitle = "HIGH SECURITY";
                    AbstractLoginDialog.DefaultLoginPlaceholder = "WHO ARE YOU?";
                    AbstractLoginDialog.DefaultPasswordPlaceholder = "SUPER SECRET PASSWORD";
                    AbstractProgressDialog.DefaultTitle = "WAIT A MINUTE";

                    // TOAST
                    AbstractToastDialog.DefaultDuration = TimeSpan.FromSeconds(5);

                    AbstractToastDialog.InfoBackgroundColor = System.Drawing.Color.Aqua;
                    AbstractToastDialog.SuccessTextColor = System.Drawing.Color.Blue;
                    AbstractToastDialog.SuccessBackgroundColor = System.Drawing.Color.BurlyWood;
                    AbstractToastDialog.WarnBackgroundColor = System.Drawing.Color.BlueViolet;
                    AbstractToastDialog.ErrorBackgroundColor = System.Drawing.Color.DeepPink;

                    UserDialogs.Instance.Alert("Default Settings Updated - Now run samples");
                }),
                Btn("Reset Default Settings", () => {
                    // CANCEL
                    AbstractActionSheetDialog.DefaultCancelText = AbstractConfirmDialog.DefaultCancelText = AbstractLoginDialog.DefaultCancelText = AbstractPromptDialog.DefaultCancelText = AbstractProgressDialog.DefaultCancelText = "Cancel";

                    // OK
                    AbstractAlertDialog.DefaultOkText = AbstractConfirmDialog.DefaultOkText = AbstractLoginDialog.DefaultOkText = AbstractPromptDialog.DefaultOkText = "Ok";

                    // CUSTOM
                    AbstractActionSheetDialog.DefaultDestructiveText = "Remove";
                    AbstractConfirmDialog.DefaultYes = "Yes";
                    AbstractConfirmDialog.DefaultNo = "No";
                    AbstractLoginDialog.DefaultTitle = "Login";
                    AbstractLoginDialog.DefaultLoginPlaceholder = "User Name";
                    AbstractLoginDialog.DefaultPasswordPlaceholder = "Password";
                    AbstractProgressDialog.DefaultTitle = "Loading";

                    AbstractToastDialog.DefaultDuration = TimeSpan.FromSeconds(3);

                    UserDialogs.Instance.Alert("Default Settings Restored");

                    // TODO: toast defaults
                })
            );
        }


        void AddPage(string title, params View[] views) {
            var content = new StackLayout();
            foreach (var view in views)
                content.Children.Add(view);

            this.Children.Add(new NavigationPage(new ContentPage {
                Content = new ScrollView {
                    Content = content
                },
                Title = title
            }) { Title = title });
        }


        static Button Btn(string text, Func<Task> action) {
            return new Button {
                Text = text,
                Command = new Command(async () => {
                    try {
                        await action();
                    }
                    catch (OperationCanceledException) { }
                })
            };
        }


        static Button Btn(string text, Action action) {
            return new Button {
                Text = text,
                Command = new Command(() => {
                    try {
                        action();
                    }
                    catch (OperationCanceledException) { }
                })
            };
        }


        void Result(string msg) {
            UserDialogs.Instance.Alert(msg);
        }


        async Task Alert() {
			var alert = UserDialogs
				.Instance
				.AlertBuilder()
				.SetTitle("Hi")
				.SetMessage("Test alert");

			this.dialog = alert;
			await alert.Request();
        }


        void ActionSheet() {
			var cfg = UserDialogs
				.Instance
                .ActionSheetBuilder()
				.SetTitle("Test Title");

            //var testImage = BitmapLoader.Current.LoadFromResource("icon.png", null, null).Result;

            for (var i = 0; i < 5; i++) {
                var display = (i + 1);
                cfg.Add(
					"Option " + display,
					() => this.Result($"Option {display} Selected")
                    //testImage
                );
            }
			cfg.SetDestructiveOption(action: () => this.Result("Destructive BOOM Selected"));
			cfg.SetCancelOption(action: () => this.Result("Cancel Selected"));

            cfg.Show();
        }


        public async Task ActionSheetAsync() {
            var result = await UserDialogs.Instance.ActionSheetAsync("Test Title", "Cancel", "Destroy", "Button1", "Button2", "Button3");
            this.Result(result);
        }


        async Task Confirm() {
            var confirm = UserDialogs
                .Instance
                .ConfirmBuilder()
                .SetYesNoButtons()
                .SetTitle("Hi")
				.SetMessage("Choose your destiny");
			this.dialog = confirm;

			var r = await confirm.Request();
            var text = r ? "Yes" : "No";
            this.Result($"Confirmation Choice: {text}");
        }


        async Task Login() {
			var login = UserDialogs
				.Instance
                .LoginBuilder()
                .SetTitle("Login!")
                .SetMessage("DANGER")
                .SetLoginPlaceholder("Username")
                .SetPasswordPlaceholder("Guess if you can")
                .SetOkText("Go")
				.SetCancelText("Poof");
			this.dialog = login;

			var r = await login.Request();
            var status = r.Ok ? "Success" : "Cancelled";
            this.Result($"Login {status} - User Name: {r.LoginText} - Password: {r.Password}");
        }


		void Prompt() {
			UserDialogs
                .Instance
                .ActionSheetBuilder()
                .SetTitle("Choose Type")
				.Add("Default", () => this.PromptCommand(InputType.Default))
				.Add("E-Mail", () => this.PromptCommand(InputType.Email))
                .Add("Name", () => this.PromptCommand(InputType.Name))
				.Add("Number", () => this.PromptCommand(InputType.Number))
                .Add("Number with Decimal", () => this.PromptCommand(InputType.DecimalNumber))
				.Add("Password", () => this.PromptCommand(InputType.Password))
                .Add("Numeric Password (PIN)", () => this.PromptCommand(InputType.NumericPassword))
                .Add("Phone", () => this.PromptCommand(InputType.Phone))
                .Add("Url", () => this.PromptCommand(InputType.Url))
                .Show();
		}


		async Task PromptWithTextAndNoCancel() {
			var prompt = UserDialogs
                .Instance
                .PromptBuilder()
                .SetTitle("PromptWithTextAndNoCancel")
                .SetText("Existing Text")
				.SetCancellable(false);

			var result = await prompt.Request();
			this.Result($"Result - {result.Text}");
		}


		async Task PromptCommand(InputType inputType) {
            try {
			    var msg = $"Enter a {inputType.ToString().ToUpper()} value";
			    //var r = await UserDialogs.Instance.PromptAsync(msg, inputType: inputType);
			    var prompt = UserDialogs
                    .Instance
                    .PromptBuilder()
                    .SetTitle("Prompt!")
                    .SetInputType(inputType)
				    .SetMessage(msg);

			    this.dialog = prompt;
			    var r = await prompt.Request();
                this.Result(r.Ok
                    ? "OK " + r.Text
                    : "Prompt Cancelled");
            }
            catch (OperationCanceledException) { }
        }


        async void Progress() {
            var cancelled = false;

            using (var dlg = UserDialogs.Instance.Progress("Test Progress")) {
#warning TODO
                //dlg.SetCancel(() => cancelled = true);
                while (!cancelled && dlg.PercentComplete < 100) {
                    await Task.Delay(TimeSpan.FromMilliseconds(500));
                    dlg.PercentComplete += 2;
                }
            }
            this.Result(cancelled ? "Progress Cancelled" : "Progress Complete");
        }


        async void ProgressNoCancel() {
            using (var dlg = UserDialogs.Instance.Progress("Progress (No Cancel)")) {
                while (dlg.PercentComplete < 100) {
                    await Task.Delay(TimeSpan.FromSeconds(1));
                    dlg.PercentComplete += 20;
                }
            }
        }


        async void Loading(MaskType maskType) {
            var cancelSrc = new CancellationTokenSource();

			using (var dlg = UserDialogs.Instance.Loading("Loading", maskType: maskType)) {
#warning TODO
                //dlg.SetCancel(cancelSrc.Cancel);

                try {
                    await Task.Delay(TimeSpan.FromSeconds(5), cancelSrc.Token);
                }
                catch { }
            }
            this.Result(cancelSrc.IsCancellationRequested ? "Loading Cancelled" : "Loading Complete");
        }


        async void LoadingNoCancel() {
            using (UserDialogs.Instance.Loading("Loading (No Cancel)"))
                await Task.Delay(TimeSpan.FromSeconds(3));
        }


		void Toast(ToastEvent @event) {
            UserDialogs
                .Instance
                .ToastBuilder()
                .SetEvent(@event)
                .SetTitle(@event.ToString())
                .SetDescription("Testing toast functionality....fun!")
                .SetDuration(TimeSpan.FromSeconds(3))
                .SetAction(() => this.Result("Toast Pressed"))
                .Show();
        }


		async void ManualLoading() {
			UserDialogs.Instance.ShowLoading("Manual Loading");
			await Task.Delay(3000);
			UserDialogs.Instance.HideLoading();
		}


        async void LoadingToSuccess() {
            using (UserDialogs.Instance.Loading("Test Loading"))
                await Task.Delay(3000);

            UserDialogs.Instance.ShowSuccess("Success Loading!");
        }
    }
}
