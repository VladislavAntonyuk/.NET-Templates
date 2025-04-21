using Microsoft.AspNetCore.Authorization;

namespace App1.Web.Services.Auth;

public interface IRoleAuthorizationRequirement : IAuthorizationRequirement
{
	public List<string> RequiredRoles { get; }
}