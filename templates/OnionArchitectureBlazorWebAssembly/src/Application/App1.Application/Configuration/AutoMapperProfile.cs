namespace App1.Application.Configuration;

using System.Collections.ObjectModel;
using AutoMapper;
using Domain.Entities;
using Interfaces;
using UseCases;
using UseCases.Class1;
using UseCases.Class1.Commands.Create;
using UseCases.Class1.Commands.Update;
using UseCases.Class1.Queries.GetClass1;

public class AutoMapperProfile : Profile
{
	public AutoMapperProfile()
	{
		MapClass1();
	}

	private void MapClass1()
	{
		CreateMap<Class1, Class1Dto>().ReverseMap();
		CreateMap<PaginatedList<Class1>, GetClass1ByFilterResponse>()
			.ForMember(x => x.Items, dest => dest.MapFrom(x => x.Items.ToList()));
		CreateMap<IEnumerable<Class1>, GetClass1ByFilterResponse>()
			.ForMember(x => x.Items, dest => dest.MapFrom(x => x.ToList()))
			.ForMember(x => x.TotalCount, dest => dest.MapFrom(x => x.Count()));

		CreateMap<CreateClass1Command, Class1>().Ignore(x => x.Id);
		CreateMap<UpdateClass1Command, Class1>();
	}
}