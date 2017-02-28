using System;
using Android.Widget;
using Android.App;
using System.Collections.Generic;
using Android.Views;

namespace Phoneword.Droid
{
	public class ListAdapter: BaseAdapter<TranslationRecord>
	{
		Activity context;
		List<TranslationRecord> list;

		public ListAdapter(Activity context, List<TranslationRecord> list):base()
		{
			this.context = context;
			this.list = list;			
		}

		public override int Count
		{
			get { return list.Count; }
		}

		public override long GetItemId(int position)
		{
			return position;
		}

		public override TranslationRecord this[int position]
		{
			get { return list[position]; }
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			View view = convertView;

			// re-use an existing view, if one is available
			// otherwise create a new one
			if (view == null)
				view = context.LayoutInflater.Inflate(Resource.Layout.HistoryItem, parent, false);

			TranslationRecord item = this[position];
			view.FindViewById<TextView>(Resource.Id.HistoryText).Text = item.character + "-" + item.number;
			return view;
		}
	}
}

