namespace App1.Web.Areas.MicrosoftIdentity.Pages.Account;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

[AllowAnonymous]
public class SignedOutModel : PageModel
{
	public IActionResult OnGet()
	{
		return LocalRedirect("~/");
	}
}