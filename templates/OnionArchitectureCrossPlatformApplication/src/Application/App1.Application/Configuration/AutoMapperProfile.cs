namespace App1.Application.Configuration;

using AutoMapper;
using Domain.Entities;
using UseCases;
using UseCases.Class1;
using UseCases.Class1.Commands.Create;
using UseCases.Class1.Commands.Delete;
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
		CreateMap<PaginatedList<Class1>, GetClass1ByFilterResponse>();
		CreateMap<CreateClass1Command, Class1>();
		CreateMap<UpdateClass1Command, Class1>();
		CreateMap<DeleteClass1Command, Class1>();
	}
}