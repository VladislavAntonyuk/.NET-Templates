using FluentAssertions;
using NetArchTest.Rules;

namespace App1.Modules.Module1s.ArchitectureTests.Abstractions;

internal static class TestResultExtensions
{
	internal static void ShouldBeSuccessful(this TestResult testResult)
	{
		testResult.FailingTypes?.Should().BeEmpty();
	}
}