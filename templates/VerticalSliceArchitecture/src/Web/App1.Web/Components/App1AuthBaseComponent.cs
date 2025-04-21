using App1.Web.Services.User;

namespace App1.Web.Components;

using Microsoft.AspNetCore.Components;

public abstract class App1AuthBaseComponent : App1BaseComponent
{
	protected UserInfo CurrentUser { get; private set; } = null!;

	[Inject]
	public required ICurrentUserService CurrentUserService { get; set; }

	[Inject]
	public required NavigationManager NavigationManager { get; set; }

	protected override async Task OnInitializedAsync()
	{
		CurrentUser = CurrentUserService.GetCurrentUser();
		if (string.IsNullOrEmpty(CurrentUser.ProviderId))
		{
			Logout();
		}

		await I18NText.SetCurrentLanguageAsync("ua");
		await base.OnInitializedAsync();
	}

	public void Logout()
	{
		NavigationManager.NavigateTo("MicrosoftIdentity/Account/SignOut", true);
	}
}