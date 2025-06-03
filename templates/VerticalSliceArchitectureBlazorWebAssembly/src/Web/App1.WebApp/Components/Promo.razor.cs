using Microsoft.AspNetCore.Components;

namespace App1.WebApp.Components;

public partial class Promo : App1BaseComponent
{
	[Inject]
	public required NavigationManager NavigationManager { get; set; }

	private void SignIn()
	{
		NavigationManager.NavigateTo("MicrosoftIdentity/Account/SignIn", true);
	}

}