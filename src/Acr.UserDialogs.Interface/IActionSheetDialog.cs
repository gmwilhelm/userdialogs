using System;
using System.Collections.Generic;
using Splat;


namespace Acr.UserDialogs {

    public interface IActionSheetDialog : IDialog {

        void Show();

        string Title { get; set; }
        ActionOption CancelOption { get; set; }
        ActionOption DestructiveOption { get; set; }
        IList<ActionOption> Options { get; set; }
        IBitmap ItemIcon { get; set; }


        IActionSheetDialog SetTitle(string title);
		IActionSheetDialog SetCancelOption(string text = null, Action action = null);
		IActionSheetDialog SetDestructiveOption(string text = null, Action action = null);
        IActionSheetDialog Add(string text, Action action = null, IBitmap icon = null);
    }
}
