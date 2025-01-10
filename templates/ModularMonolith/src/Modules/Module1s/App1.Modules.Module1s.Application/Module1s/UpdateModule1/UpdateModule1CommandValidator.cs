using FluentValidation;

namespace App1.Modules.Module1s.Application.Module1s.UpdateModule1;

internal sealed class UpdateModule1CommandValidator : AbstractValidator<UpdateModule1Command>
{
	public UpdateModule1CommandValidator()
	{
		RuleFor(c => c.Module1Id).NotEmpty();
	}
}