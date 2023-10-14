namespace App1.WebApp.Components;

using I18nText;
using Microsoft.AspNetCore.Components;
using Toolbelt.Blazor.I18nText;

public abstract class App1BaseComponent : ComponentBase
{
	protected Translation Translation = new();

	[Inject]
	protected I18nText I18NText { get; set; } = null!;

	protected override async Task OnInitializedAsync()
	{
		Translation = await I18NText.GetTextTableAsync<Translation>(this);
		await base.OnInitializedAsync();
	}
}