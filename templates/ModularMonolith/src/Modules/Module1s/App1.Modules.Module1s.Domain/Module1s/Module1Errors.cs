using App1.Common.Domain;

namespace App1.Modules.Module1s.Domain.Module1s;

public static class Module1Errors
{
	public static Error NotFound(Guid module1Id)
	{
		return Error.NotFound("Module1s.NotFound", $"The Module1 with the identifier {module1Id} not found");
	}

	public static Error NotFound(string identityId)
	{
		return Error.NotFound("Module1s.NotFound", $"The Module1 with the IDP identifier {identityId} not found");
	}
}