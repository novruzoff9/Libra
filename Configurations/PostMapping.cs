using AdminApp.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdminApp.Configurations;

public class PostMapping : BaseEntityMapping<Post>
{
    public override void Configure(EntityTypeBuilder<Post> builder)
    {
        base.Configure(builder);

        builder.Property(p => p.Title)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(p => p.Content)
            .IsRequired();
    }
}
