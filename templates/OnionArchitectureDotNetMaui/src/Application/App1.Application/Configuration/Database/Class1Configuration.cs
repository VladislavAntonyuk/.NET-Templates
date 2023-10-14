namespace App1.Application.Configuration.Database;

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class Class1Configuration:IEntityTypeConfiguration<Class1>
{
	public void Configure(EntityTypeBuilder<Class1> builder)
	{
		builder.HasIndex(e => e.Name).IsUnique();
	}
}