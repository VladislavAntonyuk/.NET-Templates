namespace App1.ApiService.Infrastructure.Auth;

public class AdministratorAuthorizationRequirement : IRoleAuthorizationRequirement
{
	public List<string> RequiredRoles => ["Administrator"];
}