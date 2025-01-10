using System.Reflection;
using App1.Modules.Module1s.Application;
using App1.Modules.Module1s.Domain.Module1s;
using App1.Modules.Module1s.Infrastructure;

namespace App1.Modules.Module1s.ArchitectureTests.Abstractions;

public abstract class BaseTest
{
	protected static readonly Assembly ApplicationAssembly = typeof(AssemblyReference).Assembly;

	protected static readonly Assembly DomainAssembly = typeof(Module1).Assembly;

	protected static readonly Assembly InfrastructureAssembly = typeof(Module1sModule).Assembly;

	protected static readonly Assembly PresentationAssembly = typeof(Module1s.Presentation.AssemblyReference).Assembly;
}