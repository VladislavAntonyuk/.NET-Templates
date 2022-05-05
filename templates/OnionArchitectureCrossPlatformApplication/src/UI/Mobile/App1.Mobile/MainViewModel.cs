namespace App1.Mobile;

using System.Collections.ObjectModel;
using Application.Interfaces.CQRS;
using Application.UseCases.Class1;
using Application.UseCases.Class1.Commands.Create;
using Application.UseCases.Class1.Queries.GetClass1;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

public partial class MainViewModel : ObservableObject
{
	private readonly IQueryDispatcher queryDispatcher;
	private readonly ICommandDispatcher commandDispatcher;

	[ObservableProperty]
	private ObservableCollection<Class1Dto> items = new();

	public MainViewModel(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
	{
		this.queryDispatcher = queryDispatcher;
		this.commandDispatcher = commandDispatcher;
	}

	[ICommand]
	async Task GetItems(CancellationToken cancellationToken)
	{
		var result = await queryDispatcher.SendAsync<GetClass1ByFilterResponse, GetClass1Query>(new GetClass1Query
		{
			Limit = 25
		}, cancellationToken);
		if (result.IsSuccessful)
		{
			items = new ObservableCollection<Class1Dto>(result.Value.Items);
		}
	}

	[ICommand]
	async Task CreateItem(CancellationToken cancellationToken)
	{
		var result = await commandDispatcher.SendAsync<Class1Dto, CreateClass1Command>(new CreateClass1Command
		{
			Name = Path.GetRandomFileName()
		}, cancellationToken);
		if (result.IsSuccessful)
		{
			await GetItems(cancellationToken);
		}
	}
}
