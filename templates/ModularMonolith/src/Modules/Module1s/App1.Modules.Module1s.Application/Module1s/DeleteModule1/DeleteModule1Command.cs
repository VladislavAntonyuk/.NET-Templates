using App1.Common.Application.Messaging;

namespace App1.Modules.Module1s.Application.Module1s.DeleteModule1;

public sealed record DeleteModule1Command(Guid Module1Id) : ICommand;