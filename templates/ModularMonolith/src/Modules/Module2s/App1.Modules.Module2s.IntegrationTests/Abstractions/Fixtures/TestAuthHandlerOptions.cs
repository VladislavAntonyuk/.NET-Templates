using Microsoft.AspNetCore.Authentication;

namespace App1.Modules.Module2s.IntegrationTests.Abstractions.Fixtures;

public class TestAuthHandlerOptions : AuthenticationSchemeOptions
{
	public bool FakeSuccessfulAuthentication { get; set; } = true;

	public bool FailPermission { get; set; }
}