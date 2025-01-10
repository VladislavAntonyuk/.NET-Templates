using App1.Common.Domain;

namespace App1.Modules.Module2s.Domain.Module2s;

public static class Module2Errors
{
	public static Error NotFound(Guid module2Id)
	{
		return Error.NotFound("Module2s.NotFound", $"The Module2 with the identifier {module2Id} not found");
	}

	public static Error NotFound(string identityId)
	{
		return Error.NotFound("Module2s.NotFound", $"The Module2 with the IDP identifier {identityId} not found");
	}
}