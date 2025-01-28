namespace App1.Common.Infrastructure.Authentication;

using System.Security.Claims;
using Application.Exceptions;
using Microsoft.Identity.Web;

public static class ClaimsPrincipalExtensions
{
	public static Guid GetModule1Id(this ClaimsPrincipal? principal)
	{
		var module1Id = principal?.GetObjectId();

		return Guid.TryParse(module1Id, out var parsedModule1Id)
			? parsedModule1Id
			: throw new App1Exception("Module1 identifier is unavailable");
	}
}