namespace App1.Mobile;

public partial class MainPage : ContentPage
{
	public MainPage(MainViewModel mainViewModel)
	{
		InitializeComponent();
		BindingContext = mainViewModel;
	}
}

