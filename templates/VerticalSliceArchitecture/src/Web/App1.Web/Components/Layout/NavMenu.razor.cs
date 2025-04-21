namespace App1.Web.Components.Layout;

using System.Reflection;
using System.Runtime.Versioning;

public partial class NavMenu : App1BaseComponent
{
	private string? frameworkName = string.Empty;

	protected override async Task OnInitializedAsync()
	{
		await base.OnInitializedAsync();
		frameworkName = Assembly.GetEntryAssembly()?.GetCustomAttribute<TargetFrameworkAttribute>()?.FrameworkName;
	}
}