using App1.Modules.Module2s.Domain.Module2s;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App1.Modules.Module2s.Infrastructure.Module2s;

internal sealed class Module2Configuration : IEntityTypeConfiguration<Domain.Module2s.Module2>
{
	public void Configure(EntityTypeBuilder<Domain.Module2s.Module2> builder)
	{
		builder.HasKey(u => u.Id);
	}
}