using Microsoft.AspNetCore.Authorization;

namespace App1.Shared.Infrastructure.Auth;

public interface IRoleAuthorizationRequirement : IAuthorizationRequirement
{
	public List<string> RequiredRoles { get; }
}