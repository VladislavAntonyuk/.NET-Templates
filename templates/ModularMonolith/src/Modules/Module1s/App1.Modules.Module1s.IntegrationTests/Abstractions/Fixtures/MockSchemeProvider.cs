using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;

namespace App1.Modules.Module1s.IntegrationTests.Abstractions.Fixtures;

public class MockSchemeProvider : AuthenticationSchemeProvider
{
    private readonly IOptionsMonitor<TestAuthHandlerOptions> fakeOptions;

    public MockSchemeProvider(IOptions<AuthenticationOptions> options, IOptionsMonitor<TestAuthHandlerOptions> fakeOptions) : base(options)
    {
        this.fakeOptions = fakeOptions;
    }

    protected MockSchemeProvider(
        IOptions<AuthenticationOptions> options,
        IOptionsMonitor<TestAuthHandlerOptions> fakeOptions,
        IDictionary<string, AuthenticationScheme> schemes) : base(options, schemes)
    {
        this.fakeOptions = fakeOptions;
    }

    public override Task<AuthenticationScheme?> GetSchemeAsync(string name)
    {
        if (fakeOptions.CurrentValue.FakeSuccessfulAuthentication)
        {
            var scheme = new AuthenticationScheme(
                TestAuthHandler.AuthenticationScheme,
                TestAuthHandler.AuthenticationScheme,
                typeof(TestAuthHandler));
            return Task.FromResult<AuthenticationScheme?>(scheme);
        }

        return base.GetSchemeAsync(name);
    }
}
