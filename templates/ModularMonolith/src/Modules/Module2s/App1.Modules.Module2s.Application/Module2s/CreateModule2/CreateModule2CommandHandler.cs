using App1.Common.Application.Messaging;
using App1.Common.Domain;
using App1.Modules.Module2s.Application.Abstractions.Data;
using App1.Modules.Module2s.Domain.Module2s;

namespace App1.Modules.Module2s.Application.Module2s.CreateModule2;

internal sealed class CreateModule2CommandHandler(
	IModule2Repository module2Repository,
	IUnitOfWork unitOfWork) : ICommandHandler<CreateModule2Command, Module2Response>
{
	public async Task<Result<Module2Response>> Handle(CreateModule2Command request, CancellationToken cancellationToken)
	{
		var module2 = await module2Repository.GetAsync(request.ProviderId, cancellationToken);
		if (module2 is null)
		{
			module2 = Module2.Create(request.ProviderId);
			module2Repository.Insert(module2);

			await unitOfWork.SaveChangesAsync(cancellationToken);
		}

		return new Module2Response(module2.Id);
	}
}