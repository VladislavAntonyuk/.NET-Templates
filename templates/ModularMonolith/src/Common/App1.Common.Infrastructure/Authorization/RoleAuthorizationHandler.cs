namespace App1.Common.Infrastructure.Authorization;

using Microsoft.AspNetCore.Authorization;

public abstract class RoleAuthorizationHandler<T> : AuthorizationHandler<T> where T : IRoleAuthorizationRequirement
{
	protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, T requirement)
	{
		var isAuthenticated = context.User.Identity?.IsAuthenticated ?? false;
		if (!isAuthenticated)
		{
			context.Fail();
		}

		if (context.User.HasClaim(c => c.Type == "extension_Groups" &&
		                               requirement.RequiredRoles.TrueForAll(x => c.Value.Split(',').Contains(x))))
		{
			context.Succeed(requirement);
		}
		else
		{
			context.Fail();
		}

		return Task.CompletedTask;
	}
}