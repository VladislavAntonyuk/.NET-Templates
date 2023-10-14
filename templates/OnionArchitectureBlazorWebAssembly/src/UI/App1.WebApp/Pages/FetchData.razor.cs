namespace App1.WebApp.Pages;

using Application.Interfaces.CQRS;
using Application.UseCases.Class1.Commands.Create;
using Application.UseCases.Class1.Commands.Delete;
using Application.UseCases.Class1.Commands.Update;
using Application.UseCases.Class1.Models;
using Application.UseCases.Class1.Queries.GetClass1;
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
		var result = await QueryDispatcher.SendAsync<GetClass1ByFilterResponse, GetClass1Query>(new GetClass1Query
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
		var result = await CommandDispatcher.SendAsync<Class1Dto, CreateClass1Command>(new CreateClass1Command
		{
			Name = DateTime.Now.ToString("O")
		}, CancellationToken.None);
		if (result.IsSuccessful)
		{
			Snackbar.Add("Created", Severity.Success);
			await table.ReloadServerData();
		}
		else
		{
			Snackbar.Add(result.Errors.FirstOrDefault("Error has occurred"), Severity.Error);
		}
	}

	private Task OnSearch(string text)
	{
		return table.ReloadServerData();
	}

	private async Task Delete(int id)
	{
		var result = await CommandDispatcher.SendAsync<bool, DeleteClass1Command>(new DeleteClass1Command(id), CancellationToken.None);
		if (result.IsSuccessful)
		{
			Snackbar.Add("Deleted", Severity.Success);
			await table.ReloadServerData();
		}
		else
		{
			Snackbar.Add(result.Errors.FirstOrDefault("Error has occurred"), Severity.Error);
		}
	}

	private async Task Update(int id)
	{
		var result = await CommandDispatcher.SendAsync<bool, UpdateClass1Command>(new UpdateClass1Command(id)
		{
			Name = DateTime.Now.ToString("O")
		}, CancellationToken.None);
		if (result.IsSuccessful)
		{
			Snackbar.Add("Updated", Severity.Success);
			await table.ReloadServerData();
		}
		else
		{
			Snackbar.Add(result.Errors.FirstOrDefault("Error has occurred"), Severity.Error);
		}
	}
}