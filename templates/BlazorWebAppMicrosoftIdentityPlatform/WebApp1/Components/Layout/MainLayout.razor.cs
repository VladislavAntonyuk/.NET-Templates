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
        if (firstRender)
        {
            if (mudThemeProvider is not null)
            {
                isDarkMode = await mudThemeProvider.GetSystemPreference();
            }
        }

        await base.OnAfterRenderAsync(firstRender);
    }
}