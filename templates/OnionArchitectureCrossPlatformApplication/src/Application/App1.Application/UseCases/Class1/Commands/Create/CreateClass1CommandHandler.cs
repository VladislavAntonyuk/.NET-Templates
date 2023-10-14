namespace App1.Application.UseCases.Class1.Commands.Create;

using Configuration.Database;
using Domain.Entities;
using Interfaces.CQRS;
using Mediator;
using Microsoft.EntityFrameworkCore;
using Models;

public class CreateClass1CommandHandler(IDbContextFactory<ApplicationContext> dbContextFactory) : ICommandHandler<CreateClass1Command, OperationResult<Class1Dto>>
{
	public async ValueTask<OperationResult<Class1Dto>> Handle(CreateClass1Command command, CancellationToken cancellationToken)
	{
		var class1 = new Class1
		{
			Name = command.Name
		};
		await using var dbContext = await dbContextFactory.CreateDbContextAsync(cancellationToken);
		var result = await dbContext.Class1.AddAsync(class1, cancellationToken);
		await dbContext.SaveChangesAsync(cancellationToken);
		return new OperationResult<Class1Dto>
		{
			Value = Class1Dto.From(result.Entity)
		};
	}
}