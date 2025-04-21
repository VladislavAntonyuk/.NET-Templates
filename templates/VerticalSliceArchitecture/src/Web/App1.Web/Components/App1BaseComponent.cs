namespace App1.Web.Components;

using I18nText;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Toolbelt.Blazor.I18nText;

public abstract class App1BaseComponent : MudComponentBase
{
	protected Translation Translation = new();

	[Inject]
	public required I18nText I18NText { get; set; }

	protected override async Task OnInitializedAsync()
	{
		Translation = await I18NText.GetTextTableAsync<Translation>(this);
		await base.OnInitializedAsync();
	}
}