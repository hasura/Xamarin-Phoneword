using System;
using Foundation;
using UIKit;

namespace Phoneword.iOS
{
	public partial class ViewController : UIViewController
	{
		string translatedNumber = "";
		ApiService apiService = new ApiService();

		public ViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			TranslateButton.TouchUpInside += (object sender, EventArgs e) =>
			{
				// Convert the phone number with text to a number	
				// using PhoneTranslator.cs
				translatedNumber = PhonewordTranslator.ToNumber(PhonewordText.Text);
				// Dismiss the keyboard if text field was tapped
				PhonewordText.ResignFirstResponder();
				makeInsertCall();
			};
			CallButton.TouchUpInside += (object sender, EventArgs e) =>
			{
				// Use URL handler with tel: prefix to invoke Apple's Phone app...
				var url = new NSUrl("tel:" + translatedNumber);
				if (!UIApplication.SharedApplication.OpenUrl(url))
				{
					var alert = UIAlertController.Create("Not supported", "Scheme 'tel:' is not supported on this device", UIAlertControllerStyle.Alert);
					alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));
					PresentViewController(alert, true, null);
				}
			};
			HistoryButton.TouchUpInside += (object sender, EventArgs e) =>
			{
				
			};
		}

		public async void makeInsertCall()
		{
			TranslationRecord record = new TranslationRecord();
			record.character = PhonewordText.Text;
			record.number = translatedNumber;
			var response = await apiService.AddTranslation(record);
			System.Diagnostics.Debug.Write(response.affectedRows);
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.		
		}
	}
}
