﻿namespace App1.Application.UseCases.Class1.Commands.Create;

using FluentValidation;
using Interfaces.Repositories;

public class CreateClass1CommandValidator : AbstractValidator<CreateClass1Command>
{
	private readonly IUnitOfWork unitOfWork;

	public CreateClass1CommandValidator(IUnitOfWork unitOfWork)
	{
		this.unitOfWork = unitOfWork;

		ConfigureValidation();
	}

	private void ConfigureValidation()
	{
		RuleFor(x => x).NotEmpty();

		RuleFor(x => x.Name)
			.NotEmpty()
			.MustAsync(async (command, name, ctx, cancellationToken) =>
			{
				var isExist = await unitOfWork.Class1Repository.IsExist(name, cancellationToken);

				if (!isExist)
				{
					return true;
				}

				ctx.AddFailure(nameof(command.Name), $"Class1 with Name:'{command.Name}' already exist");
				return false;
			});
	}
}