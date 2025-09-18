namespace App1.Client;

using Android.App;
using Android.Runtime;

[Application]
public class MainApplication : MauiApplication
{
	protected override MauiApp CreateMauiApp()
	{
		return MauiProgram.CreateMauiApp();
	}

	public MainApplication(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
	{
	}
}