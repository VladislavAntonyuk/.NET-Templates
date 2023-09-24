namespace App1.Client;

using Application = Microsoft.Maui.Controls.Application;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}