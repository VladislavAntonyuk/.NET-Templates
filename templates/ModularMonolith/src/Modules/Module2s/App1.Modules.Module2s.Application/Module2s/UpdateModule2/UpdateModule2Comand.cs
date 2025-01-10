using App1.Common.Application.Messaging;

namespace App1.Modules.Module2s.Application.Module2s.UpdateModule2;

public sealed record UpdateModule2Command(Guid Module2Id) : ICommand;