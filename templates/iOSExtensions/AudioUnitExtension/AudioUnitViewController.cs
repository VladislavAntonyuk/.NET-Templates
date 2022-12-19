using System;

using AudioUnit;
using Foundation;
using CoreAudioKit;

namespace AudioUnitExtension
{
	public partial class AudioUnitViewController : AUViewController, IAUAudioUnitFactory
	{
		AUAudioUnit? audioUnit;

		public AudioUnitViewController (IntPtr handle) : base (handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			if (audioUnit == null)
				return;

			// Get the parameter tree and add observers for any parameters that the UI needs to keep in sync with the AudioUnit
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}

		[Export ("createAudioUnitWithComponentDescription:error:")]
		public AUAudioUnit CreateAudioUnit (AudioComponentDescription desc, out NSError? error)
		{
			audioUnit = new AUAudioUnit (desc, AudioComponentInstantiationOptions.OutOfProcess, out error);
			return audioUnit;
		}
	}
}
