namespace App1.Infrastructure.WebApp.Data.Repositories;

using Application.Interfaces.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Models;

public sealed class UnitOfWork : IUnitOfWork
{
	private readonly IMapper mapper;
	private readonly WebAppContext context;
	private IClass1Repository? class1Repository;

	private IDbContextTransaction? transaction;

	public UnitOfWork(
		IDbContextFactory<WebAppContext> factory,
		IMapper mapper)
	{
		this.mapper = mapper;
		context = factory.CreateDbContext();
	}

	public IClass1Repository Class1Repository
	{
		get
		{
			class1Repository ??= new Class1Repository(context, mapper);
			return class1Repository;
		}
	}

	public async Task Save(CancellationToken cancellationToken)
	{
		foreach (var entry in context.ChangeTracker.Entries<BaseModel>())
		{
			switch (entry.State)
			{
				case EntityState.Added:
					entry.Entity.CreatedBy = "currentUser.ProviderId";
					entry.Entity.CreatedOn = DateTime.UtcNow;
					break;

				case EntityState.Modified:
					entry.Entity.ModifiedBy = "currentUser.ProviderId";
					entry.Entity.ModifiedOn = DateTime.UtcNow;
					break;
			}
		}

		try
		{
			await context.SaveChangesAsync(cancellationToken);
			if (transaction is not null)
			{
				await transaction.CommitAsync(cancellationToken);
			}
		}
		finally
		{
			if (transaction is not null)
			{
				await transaction.DisposeAsync();
			}
		}

	}

	public async Task BeginTransaction(CancellationToken cancellationToken)
	{
		transaction = await context.Database.BeginTransactionAsync(cancellationToken);
	}

	private bool disposed;

	private async ValueTask Dispose(bool disposing)
	{
		if (!disposed)
		{
			if (disposing)
			{
				await context.DisposeAsync();
			}
		}

		disposed = true;
	}

	public async ValueTask DisposeAsync()
	{
		await Dispose(true);
		GC.SuppressFinalize(this);
	}
}