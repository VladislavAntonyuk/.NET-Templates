namespace App1.Application.UseCases.Class1.Commands.Create;

using App1.Infrastructure.Data.Repositories.Models;
using Domain.Entities;
using Interfaces.CQRS;
using Microsoft.EntityFrameworkCore;

public class CreateClass1CommandHandler : ICommandHandler<Class1Dto, CreateClass1Command>
{
	private readonly IDbContextFactory<ApplicationContext> dbContextFactory;

	public CreateClass1CommandHandler(IDbContextFactory<ApplicationContext> dbContextFactory)
	{
		this.dbContextFactory = dbContextFactory;
	}

	public async ValueTask<IOperationResult<Class1Dto>> Handle(CreateClass1Command command, CancellationToken cancellationToken)
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