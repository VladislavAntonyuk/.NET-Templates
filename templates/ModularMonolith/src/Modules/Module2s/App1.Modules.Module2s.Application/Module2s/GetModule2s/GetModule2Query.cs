using App1.Common.Application.Messaging;

namespace App1.Modules.Module2s.Application.Module2s.GetModule2s;

public sealed record GetModule2SQuery : IQuery<List<Module2Response>>;