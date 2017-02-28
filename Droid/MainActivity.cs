using Android.App;
using Android.Widget;
using Android.OS;
using System.Diagnostics;

namespace Phoneword.Droid
{
	[Activity(Label = "Phoneword", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		EditText phoneNumberText;
		Button translateButton;
		Button callButton;
		Button historyButton;
		string TranslatedNumber;

		ApiService apiService = new ApiService();

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			phoneNumberText = FindViewById<EditText>(Resource.Id.PhonewordText);
			translateButton = FindViewById<Button>(Resource.Id.TranslateButton);
			callButton = FindViewById<Button>(Resource.Id.CallButton);
			historyButton = FindViewById<Button>(Resource.Id.HistoryButton);
			callButton.Enabled = false;
			translateButton.Click += TranslateButton_Click;
			callButton.Click += CallButton_Click;
			historyButton.Click += HistoryButton_Click;
		}

		private void HistoryButton_Click(object sender, System.EventArgs e)
		{
			StartActivity(typeof(TranslationHistoryActivity));
		}

		private async void TranslateButton_Click(object sender, System.EventArgs e)
		{
			TranslatedNumber = PhonewordTranslator.ToNumber(phoneNumberText.Text);
			if (string.IsNullOrWhiteSpace(TranslatedNumber))
			{
				callButton.Text = "Call";
				callButton.Enabled = false;
			}
			else
			{
				callButton.Text = "Call " + TranslatedNumber;
				callButton.Enabled = true;

				TranslationRecord record = new TranslationRecord();
				record.character = phoneNumberText.Text;
				record.number = TranslatedNumber;
				var response = await apiService.AddTranslation(record);
				System.Diagnostics.Debug.Write(response.affectedRows);
			}
		}

		private void CallButton_Click(object sender, System.EventArgs e)
		{
			var callDialog = new AlertDialog.Builder(this);
			callDialog.SetMessage("Call " + TranslatedNumber + "?");
			callDialog.SetNeutralButton("Call", delegate
			{
				//var callIntent = new Intent(Intent.ActionCall);
				//callIntent.SetData(Android.Net.Uri.Parse("tel:" + TranslatedNumber));
				//StartActivity(callIntent);

			});
			callDialog.SetNegativeButton("Cancel", delegate { });
			callDialog.Show();
		}
	}
}

