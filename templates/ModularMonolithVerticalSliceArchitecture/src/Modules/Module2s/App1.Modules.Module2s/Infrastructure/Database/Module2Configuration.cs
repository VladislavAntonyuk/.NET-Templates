using App1.Modules.Module2s.Application.Module2;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App1.Modules.Module2s.Infrastructure.Database;

internal sealed class Module2Configuration : IEntityTypeConfiguration<Module2>
{
	public void Configure(EntityTypeBuilder<Module2> builder)
	{
		builder.HasKey(u => u.Id);
	}
}