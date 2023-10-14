namespace App1.Application.UseCases.Class1.Queries.GetClass1;

using Interfaces.CQRS;
using Mediator;

public class GetClass1Query : IQuery<OperationResult<GetClass1ByFilterResponse>>;