using App1.Common.Application.Messaging;
using App1.Common.Domain;
using App1.Modules.Module1s.Domain.Module1s;

namespace App1.Modules.Module1s.Application.Module1s.GetModule1ById;

internal sealed class GetModule1QueryHandler(IModule1Repository module1Repository)
	: IQueryHandler<GetModule1Query, Module1Response>
{
	public async Task<Result<Module1Response>> Handle(GetModule1Query request, CancellationToken cancellationToken)
	{
		var module1 = await module1Repository.GetAsync(request.Module1Id, cancellationToken);

		if (module1 is null)
		{
			return Result.Failure<Module1Response>(Module1Errors.NotFound(request.Module1Id));
		}
		
		return new Module1Response(module1.Id);
	}
}