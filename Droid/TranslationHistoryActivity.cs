using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Phoneword.Droid
{
	[Activity(Label = "TranslationHistoryActivity")]
	public class TranslationHistoryActivity : Activity
	{
		ListView listView;

		ApiService apiService = new ApiService();

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.TranslationHistory);

			//Initializing listview
			listView = FindViewById<ListView>(Resource.Id.ListView);
			fetchRecords();
		}

		private async void fetchRecords()
		{
			var result = await apiService.GetTranslations();
			listView.Adapter = new ListAdapter(this, result);
		}
	}
}
