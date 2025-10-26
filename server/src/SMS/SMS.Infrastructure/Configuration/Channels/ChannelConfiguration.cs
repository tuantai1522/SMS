using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SMS.Core.Features.Channels;
using SMS.Core.Features.Teams;

namespace SMS.Infrastructure.Configuration.Channels;

public class ChannelConfiguration : IEntityTypeConfiguration<Channel>
{
    public void Configure(EntityTypeBuilder<Channel> builder)
    {
        // Rename to snake case
        builder.ToTable("channels");
        
        builder.Property(p => p.DisplayName).IsRequired();
        builder.Property(p => p.DisplayName).HasMaxLength(256);
        
        builder.Property(p => p.Description).HasMaxLength(1024);
        
        // One channel belongs to one team
        builder.HasOne<Team>()
            .WithMany()
            .HasForeignKey(c => c.TeamId);
        
        // One channel has multiple channel members
        builder.HasMany(team => team.ChannelMembers)
            .WithOne()
            .HasForeignKey(p => p.ChannelId);
    }
}