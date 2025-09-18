using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace WebApp1.Components.Layout;

public partial class MainLayout : LayoutComponentBase
{
    private bool drawerOpen = true;
    private bool isDarkMode = true;
    private MudThemeProvider? mudThemeProvider;
    private bool rightToLeft;

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
}