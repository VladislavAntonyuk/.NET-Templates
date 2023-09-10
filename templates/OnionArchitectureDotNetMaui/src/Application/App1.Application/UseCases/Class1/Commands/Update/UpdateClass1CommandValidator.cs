namespace App1.Application.UseCases.Class1.Commands.Create;

using FluentValidation;
using Infrastructure.Data.Repositories.Models;
using Microsoft.EntityFrameworkCore;

public class UpdateClass1CommandValidator : AbstractValidator<CreateClass1Command>
{
	private readonly IDbContextFactory<ApplicationContext> dbContextFactory;

	public UpdateClass1CommandValidator(IDbContextFactory<ApplicationContext> dbContextFactory)
	{
		this.dbContextFactory = dbContextFactory;

		ConfigureValidation();
	}

	private void ConfigureValidation()
	{
		RuleFor(x => x.Name)
			.NotEmpty()
			.MustAsync(async (command, name, ctx, cancellationToken) =>
			{
				await using var dbContext = await dbContextFactory.CreateDbContextAsync(cancellationToken);
				var class1 = await dbContext.Class1.FirstOrDefaultAsync(x => x.Name == name, cancellationToken);

				if (class1 is null)
				{
					return true;
				}

				ctx.AddFailure(nameof(command.Name), $"Class1 with Name:'{command.Name}' already exist");
				return false;
			});
	}
}