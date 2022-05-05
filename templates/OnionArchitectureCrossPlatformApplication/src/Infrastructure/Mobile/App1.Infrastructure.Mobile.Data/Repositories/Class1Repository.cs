namespace App1.Infrastructure.Mobile.Data.Repositories;

using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.UseCases;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Models;
using DomainClass1 = Domain.Entities.Class1;

public class Class1Repository : IClass1Repository
{
	private readonly MobileAppContext context;
	private readonly IMapper mapper;

	public Class1Repository(MobileAppContext context, IMapper mapper)
	{
		this.context = context;
		this.mapper = mapper;
	}

	public async Task<DomainClass1> Add(DomainClass1 class1, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		var newClass1 = mapper.Map<Class1>(class1);

		var resultClass1 = await context.Class1.AddAsync(newClass1, cancellationToken);

		return mapper.Map<DomainClass1>(resultClass1.Entity);
	}

	public void Update(DomainClass1 class1)
	{
		var class1ToUpdate = mapper.Map<Class1>(class1);
		context.Class1.Update(class1ToUpdate);
	}

	public void Delete(DomainClass1 class1)
	{
		var class1ToRemove = mapper.Map<Class1>(class1);
		context.Class1.Remove(class1ToRemove);
	}

	public async Task<DomainClass1?> GetById(int id, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		var class1 = await context.Class1.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
		return mapper.Map<DomainClass1>(class1);
	}

	public Task<bool> IsExist(string parameter, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		return context.Class1.AnyAsync(x => x.Name == parameter, cancellationToken);
	}

	public async Task<DomainClass1?> GetByName(string name, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		var class1 = await context.Class1.AsNoTracking().SingleOrDefaultAsync(x => x.Name.Contains(name), cancellationToken);
		return mapper.Map<DomainClass1>(class1);
	}

	public IEnumerable<DomainClass1> GetAll()
	{
		var class1 = context.Class1.AsNoTracking().AsAsyncEnumerable();
		return mapper.Map<IEnumerable<DomainClass1>>(class1);
	}

	public async Task<IPaginatedList<DomainClass1>> GetPagedAsync(string? requestName, int requestOffset, int requestLimit, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();

		var totalCount = await context.Class1
									  .AsNoTracking()
									  .CountAsync(x => x.Name.Contains(requestName ?? string.Empty), cancellationToken);

		var result = await context.Class1
						   .AsNoTracking()
						   .Where(x => x.Name.Contains(requestName ?? string.Empty))
						   .OrderBy(q => q.Id)
						   .Skip(requestOffset)
						   .Take(requestLimit)
						   .ToListAsync(cancellationToken);

		return new PaginatedList<DomainClass1>(mapper.Map<List<DomainClass1>>(result), totalCount, requestOffset,
											   requestLimit);
	}
}
