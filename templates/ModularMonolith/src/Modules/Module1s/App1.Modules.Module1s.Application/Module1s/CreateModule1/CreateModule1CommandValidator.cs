using FluentValidation;

namespace App1.Modules.Module1s.Application.Module1s.CreateModule1;

internal sealed class CreateModule1CommandValidator : AbstractValidator<CreateModule1Command>
{
	public CreateModule1CommandValidator()
	{
		RuleFor(c => c.ProviderId).NotEmpty();
	}
}