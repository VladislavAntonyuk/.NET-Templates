using System.Reflection;
using System.Runtime.Versioning;
using App1.WebApp.Components;

namespace App1.WebApp.Layout;

public partial class NavMenu : App1BaseComponent
{
	private string? frameworkName = string.Empty;

	protected override async Task OnInitializedAsync()
	{
		await base.OnInitializedAsync();
		frameworkName = Assembly.GetEntryAssembly()?.GetCustomAttribute<TargetFrameworkAttribute>()?.FrameworkName;
	}
}