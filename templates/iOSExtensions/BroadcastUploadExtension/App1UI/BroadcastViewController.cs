using System;

using Foundation;
using ReplayKit;
using UIKit;

namespace BroadcastUploadExtensionUI
{
	public partial class BroadcastViewController : UIViewController
	{
		protected BroadcastViewController (IntPtr handle) : base (handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public void UserDidFinishSetup ()
		{
			// Broadcast url that will be returned to the application
			var broadcastURL = NSUrl.FromString ("http://broadcastURL_example/stream1");
			if (broadcastURL is null)
			{
				return;
			}

			// Service specific broadcast data example which will be supplied to the process extension during broadcast
			var keys = new [] { "userID", "endpointURL" };
			var objects = new [] { "user1", "http://broadcastURL_example/stream1/upload" };
			var setupInfo = NSDictionary.FromObjectsAndKeys (objects, keys);

			// Set broadcast settings
			var broadcastConfig = new RPBroadcastConfiguration {
				ClipDuration = 5.0 // deliver movie clips every 5 seconds
			};

			if (ExtensionContext is null)
			{
				return;
			}

			// Tell ReplayKit that the extension is finished setting up and can begin broadcasting
			ExtensionContext.CompleteRequest (broadcastURL, broadcastConfig, (NSDictionary<NSString, INSCoding>?)setupInfo);
		}

		public void UserDidCancelSetup ()
		{
            if(ExtensionContext is null)
            {
                return;
            }

            ExtensionContext.CancelRequest (new NSError (new NSString ("YourAppDomain"), -1, null));
		}
	}
}

