namespace App1.Mobile.ViewModels;

using System.Collections.ObjectModel;
using Application.Interfaces.CQRS;
using Application.UseCases.Class1;
using Application.UseCases.Class1.Commands.Create;
using Application.UseCases.Class1.Commands.Delete;
using Application.UseCases.Class1.Commands.Update;
using Application.UseCases.Class1.Queries.GetClass1;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

public partial class MainViewModel : ObservableObject
{
	private readonly ICommandDispatcher commandDispatcher;
	private readonly IQueryDispatcher queryDispatcher;

	[ObservableProperty]
	private ObservableCollection<Class1Dto> items = new();

	public MainViewModel(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
	{
		this.queryDispatcher = queryDispatcher;
		this.commandDispatcher = commandDispatcher;
		GetItemsCommand.Execute(null);
	}

	[ICommand]
	private async Task GetItems(CancellationToken cancellationToken)
	{
		var result = await queryDispatcher.SendAsync<GetClass1ByFilterResponse, GetClass1Query>(new GetClass1Query
		{
			Limit = 25
		}, cancellationToken);
		if (result.IsSuccessful)
		{
			items.Clear();
			foreach (var item in result.Value.Items)
			{
				items.Add(item);
			}
		}
		else
		{
			var errors = string.Join(Environment.NewLine, result.Errors);
			await Toast.Make(errors, ToastDuration.Long).Show(cancellationToken);
		}
	}

	[ICommand]
	private async Task CreateItem(CancellationToken cancellationToken)
	{
		var result = await commandDispatcher.SendAsync<Class1Dto, CreateClass1Command>(new CreateClass1Command
		{
			Name = DateTime.Now.ToString("O")
		}, cancellationToken);
		if (result.IsSuccessful)
		{
			await GetItems(cancellationToken);
		}
		else
		{
			var errors = string.Join(Environment.NewLine, result.Errors);
			await Toast.Make(errors, ToastDuration.Long).Show(cancellationToken);
		}
	}

	[ICommand]
	private async Task UpdateItem(int itemId, CancellationToken cancellationToken)
	{
		var result = await commandDispatcher.SendAsync<Class1Dto, UpdateClass1Command>(new UpdateClass1Command(itemId)
		{
			Name = DateTime.Now.ToString("O")
		}, cancellationToken);
		if (result.IsSuccessful)
		{
			await GetItems(cancellationToken);
		}
		else
		{
			var errors = string.Join(Environment.NewLine, result.Errors);
			await Toast.Make(errors, ToastDuration.Long).Show(cancellationToken);
		}
	}

	[ICommand]
	private async Task DeleteItem(int itemId, CancellationToken cancellationToken)
	{
		var result = await commandDispatcher.SendAsync<bool, DeleteClass1Command>(new DeleteClass1Command(itemId), cancellationToken);
		if (result.IsSuccessful)
		{
			await GetItems(cancellationToken);
		}
		else
		{
			var errors = string.Join(Environment.NewLine, result.Errors);
			await Toast.Make(errors, ToastDuration.Long).Show(cancellationToken);
		}
	}
}