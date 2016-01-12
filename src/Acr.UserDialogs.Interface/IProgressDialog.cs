using System;


namespace Acr.UserDialogs {

    public interface IProgressDialog : IDialog {

        string Title { get; set; }
	    int PercentComplete { get; set; }
		bool IsDeterministic { get; set; }
        MaskType MaskType { get; set; }
        ActionOption CancelOption { get; set; }
        void Show();

        IProgressDialog SetCancel(string cancelText = null, Action onCancel = null);
        IProgressDialog SetTitle(string title);
        IProgressDialog SetMaskType(MaskType maskType);
        IProgressDialog SetIsDeterministic(bool isDeterministic);
    }
}
