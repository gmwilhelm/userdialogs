using System;
using System.Linq;
using Android.Content;
using Android.Views;
using Android.Widget;
using Splat;


namespace Acr.UserDialogs {

    public class ActionSheetListAdapter : ArrayAdapter<ActionOption> {
        readonly AbstractActionSheetDialog config;


        public ActionSheetListAdapter(Context context, int resource, int textViewResourceId, AbstractActionSheetDialog config)
                : base(context, resource, textViewResourceId, config.Options) {
            this.config = config;
        }


        public override View GetView(int position, View convertView, ViewGroup parent) {
            //Use base class to create the View
            var view = base.GetView(position, convertView, parent);
            var textView = view.FindViewById<TextView>(Android.Resource.Id.Text1);
            var item = this.config.Options.ElementAt(position);

            textView.Text = item.Text;
            if (item.ItemIcon != null)
                textView.SetCompoundDrawablesWithIntrinsicBounds(item.ItemIcon.ToNative(), null, null, null);

            //Add margin between image and text (support various screen densities)
            var dp = (int)(10 * parent.Context.Resources.DisplayMetrics.Density + 0.5f);
            textView.CompoundDrawablePadding = dp;

            return view;
        }
    }
}