using App1.Common.Application.Messaging;
using App1.Common.Domain;
using App1.Modules.Module2s.Application.Abstractions.Data;
using App1.Modules.Module2s.Domain.Module2s;

namespace App1.Modules.Module2s.Application.Module2s.UpdateModule2;

internal sealed class UpdateModule2CommandHandler(IModule2Repository module2Repository, IUnitOfWork unitOfWork)
	: ICommandHandler<UpdateModule2Command>
{
	public async Task<Result> Handle(UpdateModule2Command request, CancellationToken cancellationToken)
	{
		var module2 = await module2Repository.GetAsync(request.Module2Id, cancellationToken);

		if (module2 is null)
		{
			return Result.Failure(Module2Errors.NotFound(request.Module2Id));
		}

		module2.Update();
		await unitOfWork.SaveChangesAsync(cancellationToken);

		return Result.Success();
	}
}