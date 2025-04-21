using App1.ApiService.Application.Module1;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App1.ApiService.Infrastructure.Database;

internal sealed class Module1Configuration : IEntityTypeConfiguration<Module1>
{
	public void Configure(EntityTypeBuilder<Module1> builder)
	{
		builder.HasKey(u => u.Id);
	}
}