namespace App1.Application.UseCases.Class1.Commands.Delete;

using Configuration.Database;
using Interfaces.CQRS;
using Mediator;
using Microsoft.EntityFrameworkCore;

public class DeleteClass1CommandHandler(IDbContextFactory<ApplicationContext> dbContextFactory) : ICommandHandler<DeleteClass1Command, OperationResult>
{
	public async ValueTask<OperationResult> Handle(DeleteClass1Command command, CancellationToken cancellationToken)
	{
		await using var dbContext = await dbContextFactory.CreateDbContextAsync(cancellationToken);
		await dbContext.Class1.Where(x => x.Id == command.Class1Id).ExecuteDeleteAsync(cancellationToken);
		return new OperationResult();
	}
}