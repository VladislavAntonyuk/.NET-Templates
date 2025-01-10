using App1.Common.Application.Messaging;
using App1.Common.Domain;
using App1.Modules.Module1s.Domain.Module1s;

namespace App1.Modules.Module1s.Application.Module1s.GetModule1s;

internal sealed class GetModule1QueryHandler(IModule1Repository module1Repository)
	: IQueryHandler<GetModule1SQuery, List<Module1Response>>
{
	public async Task<Result<List<Module1Response>>> Handle(GetModule1SQuery request, CancellationToken cancellationToken)
	{
		var dbModule1S = await module1Repository.GetAsync(cancellationToken);

		var module1S = new List<Module1Response>();
		foreach (var module1 in dbModule1S)
		{
			module1S.Add(new Module1Response(module1.Id));
		}

		return module1S;
	}
}