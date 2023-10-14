namespace App1.WebApp.Components.Pages;

using App1.Application.Interfaces.CQRS;
using App1.Application.UseCases.Class1.Commands.Create;
using App1.Application.UseCases.Class1.Commands.Delete;
using App1.Application.UseCases.Class1.Commands.Update;
using App1.Application.UseCases.Class1.Models;
using App1.Application.UseCases.Class1.Queries.GetClass1;
using Microsoft.AspNetCore.Components;
using MudBlazor;

public partial class FetchData : App1BaseComponent
{
	private MudTextField<string>? searchString;

	private MudTable<Class1Dto>? table;

	[Inject]
	public required IQueryDispatcher QueryDispatcher { get; set; }

	[Inject]
	public required ICommandDispatcher CommandDispatcher { get; set; }

	[Inject]
	public required ISnackbar Snackbar { get; set; }

	private async Task<TableData<Class1Dto>> LoadClass1s(TableState state)
	{
		var result = await QueryDispatcher.SendAsync(new GetClass1Query
		{
			Limit = state.PageSize,
			Name = searchString?.Value,
			Offset = state.Page
		}, CancellationToken.None);
		if (result.IsSuccessful)
		{
			return new TableData<Class1Dto>
			{
				TotalItems = result.Value.TotalCount,
				Items = result.Value.Items
			};
		}

		return new TableData<Class1Dto>();
	}

	private async Task CreateClass1()
	{
		var result = await CommandDispatcher.SendAsync(new CreateClass1Command
		{
			Name = DateTime.Now.ToString("O")
		}, CancellationToken.None);
		if (result.IsSuccessful)
		{
			Snackbar.Add("Created", Severity.Success);
			if (table is not null)
			{
				await table.ReloadServerData();
			}
		}
		else
		{
			Snackbar.Add(result.Errors.Select(x => x.Description).FirstOrDefault("Error has occurred"), Severity.Error);
		}
	}

	private Task OnSearch(string text)
	{
		return table is null ? Task.CompletedTask : table.ReloadServerData();
	}

	private async Task Delete(int id)
	{
		var result = await CommandDispatcher.SendAsync(new DeleteClass1Command(id), CancellationToken.None);
		if (result.IsSuccessful)
		{
			Snackbar.Add("Deleted", Severity.Success);
			if (table is not null)
			{
				await table.ReloadServerData();
			}
		}
		else
		{
			Snackbar.Add(result.Errors.Select(x => x.Description).FirstOrDefault("Error has occurred"), Severity.Error);
		}
	}

	private async Task Update(int id)
	{
		var result = await CommandDispatcher.SendAsync(new UpdateClass1Command(id)
		{
			Name = DateTime.Now.ToString("O")
		}, CancellationToken.None);
		if (result.IsSuccessful)
		{
			Snackbar.Add("Updated", Severity.Success);
			if (table is not null)
			{
				await table.ReloadServerData();
			}
		}
		else
		{
			Snackbar.Add(result.Errors.Select(x => x.Description).FirstOrDefault("Error has occurred"), Severity.Error);
		}
	}
}