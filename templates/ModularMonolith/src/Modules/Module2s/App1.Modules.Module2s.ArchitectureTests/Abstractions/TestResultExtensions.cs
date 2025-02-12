namespace App1.Modules.Module2s.ArchitectureTests.Abstractions;

internal static class TestResultExtensions
{
	internal static void ShouldBeSuccessful(this NetArchTest.Rules.TestResult testResult)
	{
		Assert.Empty(testResult.FailingTypes);
	}
}