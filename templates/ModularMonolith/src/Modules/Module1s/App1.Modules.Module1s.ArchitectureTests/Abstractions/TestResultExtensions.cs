using TestResult = NetArchTest.Rules.TestResult;

namespace App1.Modules.Module1s.ArchitectureTests.Abstractions;

internal static class TestResultExtensions
{
	internal static void ShouldBeSuccessful(this TestResult testResult)
	{
		Assert.Empty(testResult.FailingTypes);
	}
}