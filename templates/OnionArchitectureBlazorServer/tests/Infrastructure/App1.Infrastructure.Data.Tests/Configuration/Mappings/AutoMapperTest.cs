namespace App1.Infrastructure.Data.Tests.Configuration.Mappings;

using Xunit;

public class AutoMapperTest
{
	[Fact]
	public void AutoMapper_Test_All_Mappings()
	{
		TestMapper.Instance.ConfigurationProvider.AssertConfigurationIsValid();
	}
}