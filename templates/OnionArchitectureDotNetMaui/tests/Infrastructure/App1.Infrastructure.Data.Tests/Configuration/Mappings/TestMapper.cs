namespace App1.Infrastructure.Data.Tests.Configuration.Mappings;

using AutoMapper;
using Infrastructure.Data.Configuration;

internal static class TestMapper
{
	static TestMapper()
	{
		var configuration = new MapperConfiguration(cfg => cfg.AddProfile(typeof(AutoMapperProfile)));

		Instance = configuration.CreateMapper();
	}

	public static IMapper Instance { get; }
}