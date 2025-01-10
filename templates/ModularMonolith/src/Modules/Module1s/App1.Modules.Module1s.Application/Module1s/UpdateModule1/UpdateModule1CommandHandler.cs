using App1.Common.Application.Messaging;
using App1.Common.Domain;
using App1.Modules.Module1s.Application.Abstractions.Data;
using App1.Modules.Module1s.Domain.Module1s;

namespace App1.Modules.Module1s.Application.Module1s.UpdateModule1;

internal sealed class UpdateModule1CommandHandler(IModule1Repository module1Repository, IUnitOfWork unitOfWork)
	: ICommandHandler<UpdateModule1Command>
{
	public async Task<Result> Handle(UpdateModule1Command request, CancellationToken cancellationToken)
	{
		var module1 = await module1Repository.GetAsync(request.Module1Id, cancellationToken);

		if (module1 is null)
		{
			return Result.Failure(Module1Errors.NotFound(request.Module1Id));
		}

		module1.Update();
		await unitOfWork.SaveChangesAsync(cancellationToken);

		return Result.Success();
	}
}