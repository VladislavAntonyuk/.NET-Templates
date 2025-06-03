using System.Security.Claims;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace App1.WebApp.Components;

public partial class LoginControl : App1BaseComponent
{
	protected ClaimsPrincipal CurrentUser { get; private set; } = null!;

	[Inject]
	public required NavigationManager NavigationManager { get; set; }

	[Inject]
	public required AuthenticationStateProvider AuthenticationStateProvider { get; set; }

	protected override async Task OnInitializedAsync()
	{
		var state = await AuthenticationStateProvider.GetAuthenticationStateAsync();
		CurrentUser = state.User;
		if (CurrentUser.Identity is null)
		{
			Logout();
		}

		await base.OnInitializedAsync();
	}

	public void Logout()
	{
		NavigationManager.NavigateTo("MicrosoftIdentity/Account/SignOut", true);
	}

}