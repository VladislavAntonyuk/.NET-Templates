namespace App1.Infrastructure.WebApp.Data.Repositories;

using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.UseCases;
using AutoMapper;
using Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Models;
using DomainClass1 = Domain.Entities.Class1;

public class Class1Repository : BaseRepository, IClass1Repository
{
	private readonly IDbContextFactory<WebAppContext> factory;
	private readonly IMapper mapper;

	public Class1Repository(IDbContextFactory<WebAppContext> factory, IMapper mapper)
	{
		this.factory = factory;
		this.mapper = mapper;
	}

	public async Task<DomainClass1> Add(DomainClass1 class1, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		var newClass1 = mapper.Map<Class1>(class1);
		await using var context = await factory.CreateDbContextAsync(cancellationToken);
		await context.Class1.AddAsync(newClass1, cancellationToken);
		await SaveChangesAsync(context, cancellationToken);
		return mapper.Map<DomainClass1>(newClass1);
	}

	public async Task<DomainClass1> Update(DomainClass1 class1, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		var class1ToUpdate = mapper.Map<Class1>(class1);
		await using var context = await factory.CreateDbContextAsync(cancellationToken);
		context.Class1.Update(class1ToUpdate);
		await SaveChangesAsync(context, cancellationToken);
		return mapper.Map<DomainClass1>(class1ToUpdate);
	}

	public async Task Delete(DomainClass1 class1, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		var class1ToRemove = mapper.Map<Class1>(class1);
		await using var context = await factory.CreateDbContextAsync(cancellationToken);
		context.Class1.Remove(class1ToRemove);
		await SaveChangesAsync(context, cancellationToken);
	}

	public async Task<DomainClass1?> GetById(int id, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await using var context = await factory.CreateDbContextAsync(cancellationToken);
		var class1 = await context.Class1.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
		return mapper.Map<DomainClass1>(class1);
	}

	public async Task<bool> IsExist(string parameter, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await using var context = await factory.CreateDbContextAsync(cancellationToken);
		return await context.Class1.AnyAsync(x => x.Name == parameter, cancellationToken);
	}

	public async Task<IEnumerable<DomainClass1>> GetAll(CancellationToken cancellationToken)
	{
		await using var context = await factory.CreateDbContextAsync(cancellationToken);
		var class1 = context.Class1.AsNoTracking().ToListAsync(cancellationToken);
		return mapper.Map<IEnumerable<DomainClass1>>(class1);
	}

	public async Task<IPaginatedList<DomainClass1>> GetPagedAsync(string? requestName,
		int requestOffset,
		int requestLimit,
		CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await using var context = await factory.CreateDbContextAsync(cancellationToken);
		var totalCount = await context.Class1.AsNoTracking()
									  .CountAsync(x => x.Name.Contains(requestName ?? string.Empty), cancellationToken);

		var result = await context.Class1.AsNoTracking()
								  .Where(x => x.Name.Contains(requestName ?? string.Empty))
								  .OrderBy(q => q.Id)
								  .Skip(requestOffset)
								  .Take(requestLimit)
								  .ToListAsync(cancellationToken);

		return new PaginatedList<DomainClass1>(mapper.Map<List<DomainClass1>>(result), totalCount, requestOffset,
											   requestLimit);
	}

	public async Task<DomainClass1?> GetByName(string name, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await using var context = await factory.CreateDbContextAsync(cancellationToken);
		var class1 = await context.Class1.AsNoTracking()
								  .SingleOrDefaultAsync(x => x.Name.Contains(name), cancellationToken);
		return mapper.Map<DomainClass1>(class1);
	}
}