using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SMS.Core.Features.Channels;
using SMS.Core.Features.Posts;
using SMS.Core.Features.Users;

namespace SMS.Infrastructure.Configuration.Posts;

public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        // Rename to snake case
        builder.ToTable("posts");
        
        // One post belongs to one channel
        builder.HasOne<Channel>()
            .WithMany()
            .HasForeignKey(p => p.ChannelId);
        
        // One post belongs to one user
        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(p => p.UserId);
        
        // One root has multiple posts
        builder.HasMany(post => post.Posts)
            .WithOne(post => post.Root)
            .HasForeignKey(p => p.RootId);
        
        // To store string in database with enum PostType
        builder.Property(p => p.Type)
            .HasConversion(v => v.ToString(), v => Enum.Parse<PostType>(v));
        builder.Property(p => p.Type).HasMaxLength(64);
    }
}