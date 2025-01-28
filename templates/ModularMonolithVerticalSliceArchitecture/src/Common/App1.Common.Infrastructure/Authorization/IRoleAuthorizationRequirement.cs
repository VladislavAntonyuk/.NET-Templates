namespace App1.Common.Infrastructure.Authorization;

using Microsoft.AspNetCore.Authorization;

public interface IRoleAuthorizationRequirement : IAuthorizationRequirement
{
	public List<string> RequiredRoles { get; }
}