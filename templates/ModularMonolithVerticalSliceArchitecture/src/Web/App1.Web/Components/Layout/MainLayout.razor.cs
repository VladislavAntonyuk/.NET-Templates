namespace App1.Web.Components.Layout;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;

public partial class MainLayout : App1BaseLayout
{
	private bool drawerOpen = true;
	private ErrorBoundary? errorBoundary;
	private bool isDarkMode = true;
	private MudThemeProvider? mudThemeProvider;
	private bool rightToLeft;

	[Inject]
	public required NavigationManager NavigationManager { get; set; }

	private void DrawerToggle()
	{
		drawerOpen = !drawerOpen;
	}

	protected override async Task OnAfterRenderAsync(bool firstRender)
	{
		await base.OnAfterRenderAsync(firstRender);
		if (firstRender && mudThemeProvider is not null)
		{
			var isDarkSystemPreference = await mudThemeProvider.GetSystemDarkModeAsync();
			await OnSystemPreferenceChanged(isDarkSystemPreference);
			await mudThemeProvider.WatchSystemDarkModeAsync(OnSystemPreferenceChanged);
		}
	}

	private Task OnSystemPreferenceChanged(bool isDarkSystemPreference)
	{
		if (isDarkMode != isDarkSystemPreference)
		{
			isDarkMode = isDarkSystemPreference;
			StateHasChanged();
		}

		return Task.CompletedTask;
	}

	private void ResetError()
	{
		errorBoundary?.Recover();
		NavigationManager.NavigateTo("/");
	}
}