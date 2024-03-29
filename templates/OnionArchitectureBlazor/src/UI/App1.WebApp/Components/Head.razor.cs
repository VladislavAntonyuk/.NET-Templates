﻿namespace App1.WebApp.Components;

using Microsoft.AspNetCore.Components;

public partial class Head : App1BaseComponent
{
	[Inject]
	public required NavigationManager NavigationManager { get; set; }

	[Parameter]
	public string Title { get; set; } = "App1";

	[Parameter]
	public string Description { get; set; } = "App1";

	[Parameter]
	public string Image { get; set; } = "favicon.png";

	[Parameter]
	public string Keywords { get; set; } = "App1";
}