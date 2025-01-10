using App1.Common.Application.Messaging;

namespace App1.Modules.Module2s.Application.Module2s.DeleteModule2;

public sealed record DeleteModule2Command(Guid Module2Id) : ICommand;