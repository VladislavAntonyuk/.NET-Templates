using System.Security.Claims;
using Microsoft.Identity.Web;

namespace App1.Web.Services.User;

public class CurrentUserService(IHttpContextAccessor httpContextAccessor) : ICurrentUserService
{
	public UserInfo GetCurrentUser()
	{
		var module1 = httpContextAccessor.HttpContext?.User;
		if (module1 is null)
		{
			return new UserInfo();
		}

		return new UserInfo
		{
			ProviderId = module1.GetObjectId(),
			Name = module1.GetDisplayName(),
			Email = module1.FindFirstValue("emails"),
			IsNew = Convert.ToBoolean(module1.FindFirstValue("newUser"))
		};
	}
}