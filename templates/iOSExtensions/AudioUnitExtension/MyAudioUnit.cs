using System;

using AudioUnit;
using Foundation;

namespace AudioUnitExtension
{
	public class MyAudioUnit : AUAudioUnit
	{
		public AUParameterTree parameterTree;

		public override AUInternalRenderBlock InternalRenderBlock {
			get {
				return new AUInternalRenderBlock (ProcessSignals);
			}
		}

		[Export ("initWithComponentDescription:options:error:")]
		public MyAudioUnit (AudioComponentDescription description, AudioComponentInstantiationOptions options, out NSError? error)
			: base (description, options, out error)
		{
			// Create parameter objects.
			AUParameter param1 = AUParameterTree.CreateParameter (
				"param1",
				"Parameter 1",
				0, 0, 100,
				AudioUnitParameterUnit.Percent,
				string.Empty,
				0, null, null
			);

			// Initialize the parameter values.
			param1.Value = .5f;

			// Create the parameter tree.
			parameterTree = AUParameterTree.CreateTree (new [] { param1 });

			// Create the input and output busses.
			// Create the input and output bus arrays.

			// A function to provide string representations of parameter values.
			parameterTree.ImplementorStringFromValueCallback = (AUParameter param, ref float? value) => {
				switch (param.Address) {
				case 0:
					return (NSString)value?.ToString ();
				default:
					return new NSString ("?");
				}
			};

			MaximumFramesToRender = 512;
		}

		public override bool AllocateRenderResources (out NSError? outError)
		{
			if (!base.AllocateRenderResources (out outError))
				return false;

			// Validate that the bus formats are compatible.
			// Allocate your resources.

			return true;
		}

		public override void DeallocateRenderResources ()
		{
			base.DeallocateRenderResources ();

			// Deallocate your resources.
		}

		public AudioUnitStatus ProcessSignals (ref AudioUnitRenderActionFlags actionFlags, ref AudioToolbox.AudioTimeStamp timestamp, uint frameCount, nint outputBusNumber, AudioToolbox.AudioBuffers outputData, AURenderEventEnumerator realtimeEventListHead, AURenderPullInputBlock? pullInputBlock)
		{
			// Do event handling and signal processing here.
			return AudioUnitStatus.NoError;
		}
	}
}

