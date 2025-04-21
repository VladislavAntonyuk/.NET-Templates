using Microsoft.AspNetCore.Authorization;

namespace App1.ApiService.Infrastructure.Auth;

public interface IRoleAuthorizationRequirement : IAuthorizationRequirement
{
	public List<string> RequiredRoles { get; }
}