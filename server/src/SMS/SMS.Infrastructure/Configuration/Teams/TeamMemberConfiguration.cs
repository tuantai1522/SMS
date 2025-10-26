using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SMS.Core.Features.Teams;
using SMS.Core.Features.Users;

namespace SMS.Infrastructure.Configuration.Teams;

public class TeamMemberConfiguration : IEntityTypeConfiguration<TeamMember>
{
    public void Configure(EntityTypeBuilder<TeamMember> builder)
    {
        // Rename to snake case
        builder.ToTable("team_members");

        // TeamId and UserId are primary keys
        builder.HasKey(nameof(TeamMember.TeamId), nameof(TeamMember.UserId));
        
        builder.Property(c => c.TeamId).ValueGeneratedNever();
        builder.Property(c => c.UserId).ValueGeneratedNever();
        
        
        // To store string in database with enum TeamMemberRole
        builder.Property(p => p.Role)
            .HasConversion(v => v.ToString(), v => Enum.Parse<TeamMemberRole>(v));
        builder.Property(p => p.Role).HasMaxLength(64);
        
        // One team member belongs to one team
        builder.HasOne<Team>()
            .WithMany(team => team.TeamMembers)
            .HasForeignKey(p => p.TeamId);
        
        // One team member belongs to one user
        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(p => p.UserId);
    }
}