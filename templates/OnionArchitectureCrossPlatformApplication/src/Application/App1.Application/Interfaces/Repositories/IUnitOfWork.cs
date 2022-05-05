namespace App1.Application.Interfaces.Repositories;

public interface IUnitOfWork : IAsyncDisposable
{
	IClass1Repository Class1Repository { get; }
	Task Save(CancellationToken cancellationToken);
	Task BeginTransaction(CancellationToken cancellationToken);
}