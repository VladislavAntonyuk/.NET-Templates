using FluentValidation;

namespace App1.Modules.Module2s.Application.Module2s.CreateModule2;

internal sealed class CreateModule2CommandValidator : AbstractValidator<CreateModule2Command>
{
	public CreateModule2CommandValidator()
	{
		RuleFor(c => c.ProviderId).NotEmpty();
	}
}