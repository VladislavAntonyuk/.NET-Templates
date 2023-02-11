using System;

using Foundation;
using ReplayKit;

namespace BroadcastUploadExtension
{
	// To handle samples with a subclass of RPBroadcastSampleHandler set the following in the extension's Info.plist file:
	// - RPBroadcastProcessMode should be set to RPBroadcastProcessModeSampleBuffer
	// - NSExtensionPrincipalClass should be set to this class
	public class SampleHandler : RPBroadcastSampleHandler
	{
		protected SampleHandler (IntPtr handle) : base (handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void BroadcastStarted (NSDictionary<NSString, NSObject>? setupInfo)
		{
			// User has requested to start the broadcast. Setup info from the UI extension will be supplied.
		}

		public override void BroadcastPaused ()
		{
			// User has requested to pause the broadcast. Samples will stop being delivered.
		}

		public override void BroadcastResumed ()
		{
			// User has requested to resume the broadcast. Samples delivery will resume.
		}

		public override void BroadcastFinished ()
		{
			// User has requested to finish the broadcast.
		}

		public override void ProcessSampleBuffer (CoreMedia.CMSampleBuffer sampleBuffer, RPSampleBufferType sampleBufferType)
		{
			switch (sampleBufferType) {
			case RPSampleBufferType.Video:
				// Handle audio sample buffer
				break;
			case RPSampleBufferType.AudioApp:
				// Handle audio sample buffer for app audio
				break;
			case RPSampleBufferType.AudioMic:
				// Handle audio sample buffer for app audio
				break;
			}
		}
	}
}

