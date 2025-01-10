namespace App1.ApiService.Extensions;

internal static class ConfigurationExtensions
{
	internal static void AddModuleConfiguration(this IConfigurationBuilder configurationBuilder, string[] modules)
	{
		foreach (var module in modules)
		{
			configurationBuilder.AddJsonFile($"modules.{module}.json", false, true);
			configurationBuilder.AddJsonFile($"modules.{module}.Development.json", true, true);
		}
	}
}