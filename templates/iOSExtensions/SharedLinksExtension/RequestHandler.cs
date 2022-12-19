using Foundation;

namespace SharedLinksExtension
{
	[Register ("RequestHandler")]
	public class RequestHandler :  NSExtensionRequestHandling
	{
		public override void BeginRequestWithExtensionContext (NSExtensionContext context)
		{
			// The keys of the user info dictionary match what data Safari is expecting for each Shared Links item.
			// For the date, use the publish date of the content being linked.

			var userInfo = new NSDictionary ("uniqueIdentifier", "uniqueIdentifierForSampleItem", "urlString", "http://apple.com", "date", NSDate.Now);

			var extensionItem = new NSExtensionItem {
				UserInfo = userInfo,
				AttributedTitle = new NSAttributedString ("Sample title"),
				AttributedContentText = new NSAttributedString ("Sample description text")
			};

			// You can supply a custom image to be used with your link as well. Use the NSExtensionItem's attachments property.
			// extensionItem.Attachments = new [] { new NSItemProvider (NSBundle.MainBundle.GetUrlForResource ("customLinkImage", "png")) };

			context.CompleteRequest (new [] { extensionItem }, null);
		}
	}
}


