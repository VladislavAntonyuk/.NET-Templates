namespace App1.WebApp;

using I18nText;
using Microsoft.AspNetCore.Components;

public abstract class App1BaseComponent : ComponentBase
{
	protected Translation Translation = new();

	[Inject]
	public required Toolbelt.Blazor.I18nText.I18nText I18NText { get; set; }

	protected override async Task OnInitializedAsync()
	{
		Translation = await I18NText.GetTextTableAsync<Translation>(this);
		await base.OnInitializedAsync();
	}
}