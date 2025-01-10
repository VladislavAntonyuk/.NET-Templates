using App1.Common.Application.Messaging;
using App1.Common.Domain;
using App1.Modules.Module1s.Application.Abstractions.Data;
using App1.Modules.Module1s.Domain.Module1s;

namespace App1.Modules.Module1s.Application.Module1s.CreateModule1;

internal sealed class CreateModule1CommandHandler(
	IModule1Repository module1Repository,
	IUnitOfWork unitOfWork) : ICommandHandler<CreateModule1Command, Module1Response>
{
	public async Task<Result<Module1Response>> Handle(CreateModule1Command request, CancellationToken cancellationToken)
	{
		var module1 = await module1Repository.GetAsync(request.ProviderId, cancellationToken);
		if (module1 is null)
		{
			module1 = Module1.Create(request.ProviderId);
			module1Repository.Insert(module1);

			await unitOfWork.SaveChangesAsync(cancellationToken);
		}

		return new Module1Response(module1.Id);
	}
}