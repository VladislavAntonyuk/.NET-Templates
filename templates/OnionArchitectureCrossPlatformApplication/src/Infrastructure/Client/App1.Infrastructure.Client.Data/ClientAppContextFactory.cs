namespace App1.Infrastructure.Client.Data;

using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Repositories.Models;

public class ClientAppContextFactory : IDesignTimeDbContextFactory<ClientAppContext>
{
	public ClientAppContext CreateDbContext(string[] args)
	{
		var optionsBuilder = new DbContextOptionsBuilder<ClientAppContext>();
		const string connectionString = "Filename=App1.db";
		optionsBuilder.UseSqlite(connectionString, builder =>
		{
			builder.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
		});
		return new ClientAppContext(optionsBuilder.Options);
	}
}