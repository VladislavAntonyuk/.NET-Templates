namespace App1.Application.UseCases.Class1.Queries.GetClass1;

using AutoMapper;
using Interfaces.CQRS;
using Interfaces.Repositories;

public class GetClass1QueryHandler : BaseClass1Handler, IQueryHandler<GetClass1ByFilterResponse, GetClass1Query>
{
	public GetClass1QueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
	{
	}

	public async Task<IOperationResult<GetClass1ByFilterResponse>> Handle(GetClass1Query request, CancellationToken cancellationToken)
	{
		var result = await UnitOfWork.Class1Repository.GetPagedAsync(request.Name, request.Offset, request.Limit, cancellationToken);
		return new OperationResult<GetClass1ByFilterResponse>
		{
			Value = Mapper.Map<GetClass1ByFilterResponse>(result)
		};
	}
}
