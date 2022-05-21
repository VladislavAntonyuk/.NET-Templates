namespace App1.Infrastructure.WebApp.Data.Configuration;

using AutoMapper;
using Repositories.Models;

public class AutoMapperProfile : Profile
{
	public AutoMapperProfile()
	{
		SetupBanner();
	}

	private void SetupBanner()
	{
		CreateMap<Class1, Domain.Entities.Class1>().ReverseMap();
	}
}