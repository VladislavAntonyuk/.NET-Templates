using System;
using Foundation;
using UIKit;
using UserNotifications;
using UserNotificationsUI;


namespace NotificationContentExtension
{
	public partial class NotificationViewController : UIViewController, IUNNotificationContentExtension
	{
		protected NotificationViewController (IntPtr handle) : base (handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			// Do any required interface initialization here.
		}

		public void DidReceiveNotification (UNNotification notification)
		{
			label.Text = notification.Request.Content.Body;
		}
	}
}

