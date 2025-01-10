using FluentAssertions;
using NetArchTest.Rules;

namespace App1.Modules.Module2s.ArchitectureTests.Abstractions;

internal static class TestResultExtensions
{
	internal static void ShouldBeSuccessful(this TestResult testResult)
	{
		testResult.FailingTypes?.Should().BeEmpty();
	}
}