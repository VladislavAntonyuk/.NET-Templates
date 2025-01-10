using App1.Common.Application.Messaging;

namespace App1.Modules.Module1s.Application.Module1s.CreateModule1;

public sealed record CreateModule1Command(Guid ProviderId) : ICommand<Module1Response>;