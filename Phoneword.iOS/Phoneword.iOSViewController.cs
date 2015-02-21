using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Phoneword.iOS
{
	public partial class Phoneword_iOSViewController : UIViewController
	{
		public Phoneword_iOSViewController (IntPtr handle) : base (handle)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		#region View lifecycle

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			var translatedNumber = "";

			TranslateButton.TouchUpInside += (object sender, EventArgs e) => {

				// Convert the phone number with text to a number - from PhoneTranslator.cs
				translatedNumber = Core.PhoneTranslator.ToNumber(PhoneNumberText.Text);

				// Dismiss the keyboard - if Text Field was tapped
				PhoneNumberText.ResignFirstResponder ();

				//Check if the number has been translated
				if (translatedNumber == "") {
					CallButton.SetTitle ("Call ", UIControlState.Normal);
					CallButton.Enabled = false;
				} else {
					CallButton.SetTitle ("Call " + translatedNumber, UIControlState.Normal);
					CallButton.Enabled = true;
				}
			};CallButton.TouchUpInside += (object sender, EventArgs e) => {

				// Use URL handler with tel: prefix to invoke Apple's Phone app, 
				var url = new NSUrl ("tel:" + translatedNumber);

				// otherwise show an alert dialog                
				if (!UIApplication.SharedApplication.OpenUrl (url)) {
					var av = new UIAlertView ("Not supported",
						"Scheme 'tel:' is not supported on this device",
						null,
						"OK",
						null);

					av.Show ();
				}
			};
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
		}

		public override void ViewWillDisappear (bool animated)
		{
			base.ViewWillDisappear (animated);
		}

		public override void ViewDidDisappear (bool animated)
		{
			base.ViewDidDisappear (animated);
		}

		#endregion
	}
}

