namespace App1.Application.UseCases.Class1.Commands.Update;

using Configuration.Database;
using Interfaces.CQRS;
using Mediator;
using Microsoft.EntityFrameworkCore;

public class UpdateClass1CommandHandler(IDbContextFactory<ApplicationContext> dbContextFactory) : ICommandHandler<UpdateClass1Command, OperationResult>
{
	public async ValueTask<OperationResult> Handle(UpdateClass1Command command, CancellationToken cancellationToken)
	{
		await using var dbContext = await dbContextFactory.CreateDbContextAsync(cancellationToken);
		await dbContext.Class1.Where(x => x.Id == command.Id)
					   .ExecuteUpdateAsync(x => x.SetProperty(y => y.Name, command.Name), cancellationToken: cancellationToken);
		return new OperationResult();
	}
}