﻿using System;
using System.Threading;
using System.Threading.Tasks;


namespace Acr.UserDialogs {

    public abstract class ConfirmDialog : Dialog {

        public virtual string Title { get; set; }
        public virtual string Message { get; set; }
        public virtual string OkText { get; set; }
        public virtual string CancelText { get; set; }
        public abstract Task<bool> Request(CancellationToken? cancelToken = null);


        public virtual ConfirmDialog SetOkText(string text) {
            this.OkText = text;
            return this;
        }


        public virtual ConfirmDialog SetCancelText(string text) {
            this.CancelText = text;
            return this;
        }


        public virtual ConfirmDialog SetTitle(string title) {
            this.Title = title;
            return this;
        }


        public virtual ConfirmDialog SetMessage(string message) {
            this.Message = message;
            return this;
        }


        public static string DefaultYes { get; set; } = "Yes";
        public static string DefaultNo { get; set; } = "No";
        public static string DefaultOkText { get; set; } = "Ok";
        public static string DefaultCancelText { get; set; } = "Cancel";
    }
}