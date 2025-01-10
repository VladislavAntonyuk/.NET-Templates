using FluentValidation;

namespace App1.Modules.Module2s.Application.Module2s.UpdateModule2;

internal sealed class UpdateModule2CommandValidator : AbstractValidator<UpdateModule2Command>
{
	public UpdateModule2CommandValidator()
	{
		RuleFor(c => c.Module2Id).NotEmpty();
	}
}