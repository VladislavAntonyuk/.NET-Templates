namespace App1.Modules.Module2s.Infrastructure.Module2s;

public class AzureAdB2CGraphClientConfiguration
{
	public const string ConfigurationName = "AzureAdB2CGraphClient";
	public string? ClientId { get; set; }

	public string? ClientSecret { get; set; }
	public string? TenantId { get; set; }
	public string? DefaultApplicationId { get; set; }
}