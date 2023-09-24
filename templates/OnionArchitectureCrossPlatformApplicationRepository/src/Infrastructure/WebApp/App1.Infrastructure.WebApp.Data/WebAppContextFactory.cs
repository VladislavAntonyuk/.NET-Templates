#if DEBUG
namespace App1.Infrastructure.WebApp.Data;

using System.Reflection;
using Infrastructure.Data.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class WebAppContextFactory : IDesignTimeDbContextFactory<WebAppContext>
{
	public WebAppContext CreateDbContext(string[] args)
	{
		var optionsBuilder = new DbContextOptionsBuilder<WebAppContext>();
		const string connectionString = "Data Source=localhost;Initial Catalog=App1;User Id=sa;Password=P@ssword123!;timeout=20;TrustServerCertificate=True;";
		optionsBuilder.UseSqlServer(connectionString, builder =>
		{
			builder.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
		});
		return new WebAppContext(optionsBuilder.Options);
	}
}
#endif