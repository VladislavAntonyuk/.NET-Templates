namespace App1.WebApp.Components;

using Microsoft.AspNetCore.Components;

public partial class Head : App1BaseComponent
{
	[Inject]
	private NavigationManager NavigationManager { get; set; } = null!;

	[Parameter]
	public string Title { get; set; } = "App1";

	[Parameter]
	public string Description { get; set; } = "App1";

	[Parameter]
	public string Image { get; set; } = "favicon.ico";

	[Parameter]
	public string Keywords { get; set; } = "App1";
}