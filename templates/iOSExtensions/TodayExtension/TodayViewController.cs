using System;

using NotificationCenter;
using Foundation;
using UIKit;

namespace TodayExtension
{
	public partial class TodayViewController : UIViewController, INCWidgetProviding
	{
		protected TodayViewController (IntPtr handle) : base (handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();

			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			// Do any additional setup after loading the view.
		}
	}
}

