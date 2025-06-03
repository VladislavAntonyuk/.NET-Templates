namespace App1.Shared.Infrastructure.Auth;

public class AdministratorAuthorizationRequirement : IRoleAuthorizationRequirement
{
	public List<string> RequiredRoles => ["Administrator"];
}