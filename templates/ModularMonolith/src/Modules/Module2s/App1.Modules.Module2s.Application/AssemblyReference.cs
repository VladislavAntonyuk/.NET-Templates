using System.Reflection;

namespace App1.Modules.Module2s.Application;

public static class AssemblyReference
{
	public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}