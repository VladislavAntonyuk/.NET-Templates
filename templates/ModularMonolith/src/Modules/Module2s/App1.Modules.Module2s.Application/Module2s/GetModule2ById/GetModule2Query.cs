using App1.Common.Application.Messaging;

namespace App1.Modules.Module2s.Application.Module2s.GetModule2ById;

public sealed record GetModule2Query(Guid Module2Id) : IQuery<Module2Response>;