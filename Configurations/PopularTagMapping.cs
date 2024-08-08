using AdminApp.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdminApp.Configurations;

public class PopularTagMapping : BaseEntityMapping<PopularTag>
{
    public override void Configure(EntityTypeBuilder<PopularTag> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Title)
            .HasMaxLength(50)
            .IsRequired();
    }
}
