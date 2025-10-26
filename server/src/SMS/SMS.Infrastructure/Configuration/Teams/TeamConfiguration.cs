using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SMS.Core.Features.Teams;

namespace SMS.Infrastructure.Configuration.Teams;

public class TeamConfiguration : IEntityTypeConfiguration<Team>
{
    public void Configure(EntityTypeBuilder<Team> builder)
    {
        // Rename to snake case
        builder.ToTable("teams");
        
        builder.Property(p => p.DisplayName).IsRequired();
        builder.Property(p => p.DisplayName).HasMaxLength(256);
        
        builder.Property(p => p.Description).HasMaxLength(1024);
        
        // One team has multiple team members
        builder.HasMany(team => team.TeamMembers)
            .WithOne()
            .HasForeignKey(p => p.TeamId);
    }
}