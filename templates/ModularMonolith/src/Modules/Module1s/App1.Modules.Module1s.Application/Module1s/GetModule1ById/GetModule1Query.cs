using App1.Common.Application.Messaging;

namespace App1.Modules.Module1s.Application.Module1s.GetModule1ById;

public sealed record GetModule1Query(Guid Module1Id) : IQuery<Module1Response>;