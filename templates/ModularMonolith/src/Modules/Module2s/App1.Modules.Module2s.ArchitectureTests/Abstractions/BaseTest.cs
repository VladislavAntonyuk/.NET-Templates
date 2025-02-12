using System.Reflection;
using App1.Modules.Module2s.Application;
using App1.Modules.Module2s.Domain.Module2s;
using App1.Modules.Module2s.Infrastructure;

namespace App1.Modules.Module2s.ArchitectureTests.Abstractions;

public abstract class BaseTest
{
	protected static readonly Assembly ApplicationAssembly = typeof(AssemblyReference).Assembly;

	protected static readonly Assembly DomainAssembly = typeof(Module2).Assembly;

	protected static readonly Assembly InfrastructureAssembly = typeof(Module2sModule).Assembly;

	protected static readonly Assembly PresentationAssembly = typeof(Module2s.Presentation.AssemblyReference).Assembly;
}