namespace App1.Application.UseCases.Class1.Queries.GetClass1;

using AutoMapper;
using Interfaces.CQRS;
using Interfaces.Repositories;

public class GetClass1QueryHandler : BaseClass1Handler, IQueryHandler<GetClass1ByFilterResponse, GetClass1Query>
{
	public GetClass1QueryHandler(IClass1Repository class1Repository, IMapper mapper) : base(class1Repository, mapper)
	{
	}

	public async Task<IOperationResult<GetClass1ByFilterResponse>> Handle(GetClass1Query request, CancellationToken cancellationToken)
	{
		var result = await Class1Repository.GetPagedAsync(request.Name, request.Offset, request.Limit, cancellationToken);
		return new OperationResult<GetClass1ByFilterResponse>
		{
			Value = Mapper.Map<GetClass1ByFilterResponse>(result)
		};
	}
}