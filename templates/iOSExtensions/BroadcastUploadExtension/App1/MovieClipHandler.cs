using System;

using Foundation;
using ReplayKit;

namespace BroadcastUploadExtension
{
	[Register ("MovieClipHandler")]
	public class MovieClipHandler : RPBroadcastMP4ClipHandler
	{
		protected MovieClipHandler (IntPtr handle) : base (handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ProcessMP4Clip (NSUrl? mp4ClipURL, NSDictionary<NSString, NSObject>? setupInfo, bool finished)
		{
			if (mp4ClipURL is null || setupInfo is null)
			{
				return;
			}
			
			// Get the endpoint URL supplied by the UI extension in the service info dictionary
			var endpointURL = new NSUrl ((NSString)setupInfo ["endpointURL"]);

			// Set up the request
			var request = new NSMutableUrlRequest (endpointURL) {
				HttpMethod = "POST"
			};

			// Upload the movie file with an upload task
			var session = NSUrlSession.SharedSession;
			var uploadTask = session.CreateUploadTask (request, mp4ClipURL, (data, response, error) => {
				if (error != null) {
					// Handle the error locally
				}

				// Update broadcast settings
				var broadcastConfiguration = new RPBroadcastConfiguration {
					ClipDuration = 5
				};

				// Tell ReplayKit that processing is complete for thie clip
				FinishedProcessingMP4Clip (broadcastConfiguration, null);
			});

			uploadTask.Resume ();
		}
	}
}

