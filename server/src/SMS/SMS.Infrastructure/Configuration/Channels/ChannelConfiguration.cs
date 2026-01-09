using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SMS.Core.Features.Channels;

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
        
        // One channel has multiple channel members
        builder.HasMany(channel => channel.ChannelMembers)
            .WithOne()
            .HasForeignKey(p => p.ChannelId);
    }
}