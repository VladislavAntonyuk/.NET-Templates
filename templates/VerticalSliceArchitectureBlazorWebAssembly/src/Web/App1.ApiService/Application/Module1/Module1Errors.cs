using App1.ApiService.Infrastructure.Results;

namespace App1.ApiService.Application.Module1;

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