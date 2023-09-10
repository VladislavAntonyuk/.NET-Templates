namespace App1.Application.UseCases.Class1.Commands.Delete;

using App1.Infrastructure.Data.Repositories.Models;
using Interfaces.CQRS;
using Microsoft.EntityFrameworkCore;

public class DeleteClass1CommandHandler : ICommandHandler<bool, DeleteClass1Command>
{
	private readonly IDbContextFactory<ApplicationContext> dbContextFactory;

	public DeleteClass1CommandHandler(IDbContextFactory<ApplicationContext> dbContextFactory)
	{
		this.dbContextFactory = dbContextFactory;
	}

	public async ValueTask<IOperationResult<bool>> Handle(DeleteClass1Command command, CancellationToken cancellationToken)
	{
		await using var dbContext = await dbContextFactory.CreateDbContextAsync(cancellationToken);
		await dbContext.Class1.Where(x => x.Id == command.Class1Id).ExecuteDeleteAsync(cancellationToken);
		return new OperationResult<bool>()
		{
			Value = true
		};
	}
}