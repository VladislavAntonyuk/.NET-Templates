using System.Reflection;

namespace App1.Modules.Module1s;

public static class AssemblyReference
{
	public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}