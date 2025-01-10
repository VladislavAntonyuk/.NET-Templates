using App1.Common.Application.Messaging;

namespace App1.Modules.Module1s.Application.Module1s.UpdateModule1;

public sealed record UpdateModule1Command(Guid Module1Id) : ICommand;