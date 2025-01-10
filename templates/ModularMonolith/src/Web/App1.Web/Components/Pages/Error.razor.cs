namespace App1.Web.Components.Pages;

using System.Diagnostics;
using Microsoft.AspNetCore.Components;

public partial class Error : App1BaseComponent
{
	[CascadingParameter]
	public HttpContext? HttpContext { get; set; }

	public string? RequestId { get; set; }
	public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

	protected override void OnInitialized()
	{
		RequestId = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;
	}
}