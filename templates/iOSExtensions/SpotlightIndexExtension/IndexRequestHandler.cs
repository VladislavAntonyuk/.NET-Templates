using System;
using CoreSpotlight;
using Foundation;

namespace SpotlightIndexExtension
{
	[Register ("IndexRequestHandler")]
	public class IndexRequestHandler : CSIndexExtensionRequestHandler
	{
		public override void ReindexAllSearchableItems (CSSearchableIndex searchableIndex, Action acknowledgementHandler)
		{
			// Reindex all data with the provided index
			acknowledgementHandler.Invoke ();
		}

		public override void ReindexSearchableItems (CSSearchableIndex searchableIndex, string[] identifiers, Action acknowledgementHandler)
		{
			// Reindex any items with the given identifiers and the provided index
			acknowledgementHandler.Invoke ();
		}
	}
}


