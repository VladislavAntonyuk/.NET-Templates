using System.Reflection;

namespace App1.Modules.Module1s.Application;

public static class AssemblyReference
{
	public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}