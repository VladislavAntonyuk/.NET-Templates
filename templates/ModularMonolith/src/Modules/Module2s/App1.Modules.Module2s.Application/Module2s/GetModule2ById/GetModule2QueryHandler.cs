using App1.Common.Application.Messaging;
using App1.Common.Domain;
using App1.Modules.Module2s.Domain.Module2s;

namespace App1.Modules.Module2s.Application.Module2s.GetModule2ById;

internal sealed class GetModule2QueryHandler(IModule2Repository module2Repository)
	: IQueryHandler<GetModule2Query, Module2Response>
{
	public async Task<Result<Module2Response>> Handle(GetModule2Query request, CancellationToken cancellationToken)
	{
		var module2 = await module2Repository.GetAsync(request.Module2Id, cancellationToken);

		if (module2 is null)
		{
			return Result.Failure<Module2Response>(Module2Errors.NotFound(request.Module2Id));
		}
		
		return new Module2Response(module2.Id);
	}
}