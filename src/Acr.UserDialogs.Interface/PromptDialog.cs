using System;
using System.Threading.Tasks;


namespace Acr.UserDialogs {

    public abstract class PromptDialog : Dialog {

        public virtual string Title { get; set; }
        public virtual string Message { get; set; }
        public virtual string PlaceHolderText { get; set; }
        public virtual InputType InputType { get; set; }
        public abstract Task<PromptResult> Request();
    }
}
