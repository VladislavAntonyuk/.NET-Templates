using App1.Common.Application.Messaging;

namespace App1.Modules.Module2s.Application.Module2s.CreateModule2;

public sealed record CreateModule2Command(Guid ProviderId) : ICommand<Module2Response>;