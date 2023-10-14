namespace App1.Infrastructure.Data.Repositories.Models;

using Microsoft.EntityFrameworkCore;

public class WebAppContext(DbContextOptions<WebAppContext> options) : DbContext(options)
{
	public DbSet<Class1> Class1 => Set<Class1>();

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfiguration(new Class1Configuration());
	}
}