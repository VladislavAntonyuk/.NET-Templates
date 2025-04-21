namespace App1.Web.Services.Auth;

public class AdministratorAuthorizationRequirement : IRoleAuthorizationRequirement
{
	public List<string> RequiredRoles => ["Administrator"];
}