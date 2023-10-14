#if DEBUG
namespace App1.Infrastructure.Data;

using System.Reflection;
using Application.Configuration.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class WebAppContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
{
	public ApplicationContext CreateDbContext(string[] args)
	{
		var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
		const string connectionString = "Data Source=localhost;Initial Catalog=App1;User Id=sa;Password=P@ssword123!;timeout=20;TrustServerCertificate=True;";
		optionsBuilder.UseSqlServer(connectionString, builder =>
		{
			builder.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
		});
		return new ApplicationContext(optionsBuilder.Options);
	}
}
#endif