namespace App1.Common.Infrastructure.Authorization;

public class AdministratorAuthorizationRequirement : IRoleAuthorizationRequirement
{
	public List<string> RequiredRoles => ["Administrator"];
}