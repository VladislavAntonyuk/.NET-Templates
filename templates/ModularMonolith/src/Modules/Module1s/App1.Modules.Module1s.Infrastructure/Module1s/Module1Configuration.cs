using App1.Modules.Module1s.Domain.Module1s;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App1.Modules.Module1s.Infrastructure.Module1s;

internal sealed class Module1Configuration : IEntityTypeConfiguration<Module1>
{
	public void Configure(EntityTypeBuilder<Module1> builder)
	{
		builder.HasKey(u => u.Id);
	}
}