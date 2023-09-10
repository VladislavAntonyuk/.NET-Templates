namespace App1.Application.UseCases.Class1.Commands.Update;

using App1.Infrastructure.Data.Repositories.Models;
using Interfaces.CQRS;
using Microsoft.EntityFrameworkCore;

public class UpdateClass1CommandHandler : ICommandHandler<bool, UpdateClass1Command>
{
	private readonly IDbContextFactory<ApplicationContext> dbContextFactory;

	public UpdateClass1CommandHandler(IDbContextFactory<ApplicationContext> dbContextFactory)
	{
		this.dbContextFactory = dbContextFactory;
	}

	public async ValueTask<IOperationResult<bool>> Handle(UpdateClass1Command command, CancellationToken cancellationToken)
	{
		await using var dbContext = await dbContextFactory.CreateDbContextAsync(cancellationToken);
		await dbContext.Class1.Where(x => x.Id == command.Id)
					   .ExecuteUpdateAsync(x => x.SetProperty(y => y.Name, command.Name), cancellationToken: cancellationToken);
		return new OperationResult<bool>()
		{
			Value = true
		};
	}
}