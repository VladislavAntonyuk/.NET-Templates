namespace App1.Application.UseCases.Class1.Commands.Update;

using FluentValidation;
using Interfaces.Repositories;

public class UpdateClass1CommandValidator : AbstractValidator<UpdateClass1Command>
{
	private readonly IClass1Repository class1Repository;

	public UpdateClass1CommandValidator(IClass1Repository class1Repository)
	{
		this.class1Repository = class1Repository;

		ConfigureValidation();
	}

	private void ConfigureValidation()
	{
		RuleFor(x => x).NotEmpty();

		RuleFor(x => x.Name)
			.NotEmpty()
			.MustAsync(async (command, name, ctx, cancellationToken) =>
			{
				var isExist = await class1Repository.IsExist(name, cancellationToken);

				if (!isExist)
				{
					return true;
				}

				ctx.AddFailure(nameof(command.Name), $"Class1 with Name:'{command.Name}' already exist");
				return false;
			});
	}
}