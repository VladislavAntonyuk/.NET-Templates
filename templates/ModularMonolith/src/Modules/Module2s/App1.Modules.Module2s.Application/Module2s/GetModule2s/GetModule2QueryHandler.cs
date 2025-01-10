using App1.Common.Application.Messaging;
using App1.Common.Domain;
using App1.Modules.Module2s.Domain.Module2s;

namespace App1.Modules.Module2s.Application.Module2s.GetModule2s;

internal sealed class GetModule2QueryHandler(IModule2Repository module2Repository)
	: IQueryHandler<GetModule2SQuery, List<Module2Response>>
{
	public async Task<Result<List<Module2Response>>> Handle(GetModule2SQuery request, CancellationToken cancellationToken)
	{
		var dbModule2S = await module2Repository.GetAsync(cancellationToken);

		var module2S = new List<Module2Response>();
		foreach (var module2 in dbModule2S)
		{
			module2S.Add(new Module2Response(module2.Id));
		}

		return module2S;
	}
}