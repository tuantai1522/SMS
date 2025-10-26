using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SMS.Core.Features.Channels;
using SMS.Core.Features.Users;

namespace SMS.Infrastructure.Configuration.Channels;

public class ChannelMemberConfiguration : IEntityTypeConfiguration<ChannelMember>
{
    public void Configure(EntityTypeBuilder<ChannelMember> builder)
    {
        // Rename to snake case
        builder.ToTable("channel_members");

        // ChannelId and UserId are primary keys
        builder.HasKey(nameof(ChannelMember.ChannelId), nameof(ChannelMember.UserId));
        
        builder.Property(c => c.ChannelId).ValueGeneratedNever();
        builder.Property(c => c.UserId).ValueGeneratedNever();
        
        
        // To store string in database with enum ChannelMemberRole
        builder.Property(p => p.Role).HasConversion(v => v.ToString(), v => Enum.Parse<ChannelMemberRole>(v));
        builder.Property(p => p.Role).HasMaxLength(64);
        
        // One channel member belongs to one channel
        builder.HasOne<Channel>()
            .WithMany(channel => channel.ChannelMembers)
            .HasForeignKey(p => p.ChannelId);
        
        // One channel member belongs to one user
        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(p => p.UserId);
    }
}