using System;
using System.Threading;
using System.Threading.Tasks;


namespace Acr.UserDialogs {

    public class AlertDialogImpl : AlertDialog {

        public override void Show() {
            throw new NotImplementedException();
        }


        public override Task Request(CancellationToken? cancelToken = null) {
            throw new NotImplementedException();
        }
    }
}