namespace App1.Infrastructure.Client.Data.Repositories;

using Application.Interfaces.Repositories;
using Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Models;
using DomainClass1 = Domain.Entities.Class1;

public class Class1Repository(IDbContextFactory<ClientAppContext> factory) : BaseRepository, IClass1Repository
{
	public async Task<DomainClass1> Add(DomainClass1 class1, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		var newClass1 = From(class1);
		await using var context = await factory.CreateDbContextAsync(cancellationToken);
		await context.Class1.AddAsync(newClass1, cancellationToken);
		await SaveChangesAsync(context, cancellationToken);
		return From(newClass1);
	}

	public async Task<DomainClass1> Update(DomainClass1 class1, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		var class1ToUpdate = From(class1);
		await using var context = await factory.CreateDbContextAsync(cancellationToken);
		context.Class1.Update(class1ToUpdate);
		await SaveChangesAsync(context, cancellationToken);
		return From(class1ToUpdate);
	}

	public async Task Delete(DomainClass1 class1, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		var class1ToRemove = From(class1);
		await using var context = await factory.CreateDbContextAsync(cancellationToken);
		context.Class1.Remove(class1ToRemove);
		await SaveChangesAsync(context, cancellationToken);
	}

	public async Task<DomainClass1?> GetById(int id, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await using var context = await factory.CreateDbContextAsync(cancellationToken);
		var class1 = await context.Class1.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
		return class1 is null ? null : From(class1);
	}

	public async Task<bool> IsExist(string parameter, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await using var context = await factory.CreateDbContextAsync(cancellationToken);
		return await context.Class1.AnyAsync(x => x.Name == parameter, cancellationToken);
	}

	public async Task<IList<DomainClass1>> GetAll(CancellationToken cancellationToken)
	{
		await using var context = await factory.CreateDbContextAsync(cancellationToken);
		return await context.Class1.AsNoTracking().Select(x => From(x)).ToListAsync(cancellationToken);
	}

	private static DomainClass1 From(Class1 class1)
	{
		return new DomainClass1
		{
			Id = class1.Id,
			Name = class1.Name,
			CreatedOn = class1.CreatedOn,
			ModifiedOn = class1.ModifiedOn
		};
	}

	private static Class1 From(DomainClass1 class1)
	{
		return new Class1
		{
			Id = class1.Id,
			Name = class1.Name,
			CreatedOn = class1.CreatedOn,
			ModifiedOn = class1.ModifiedOn
		};
	}
}