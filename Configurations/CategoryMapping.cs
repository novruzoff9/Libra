using AdminApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace AdminApp.Configurations;

public class PopularTagPostMapping : IEntityTypeConfiguration<PopularTagPost>
{
    public void Configure(EntityTypeBuilder<PopularTagPost> builder)
    {
        builder
                .HasKey(pt => new { pt.PostId, pt.PopularTagId });

        builder
            .HasOne(pt => pt.Post)
            .WithMany(p => p!.PostPopularTags)
            .HasForeignKey(pt => pt.PostId);


        builder
            .HasOne(pt => pt.PopularTag)
            .WithMany(p => p!.PopularTagPosts)
            .HasForeignKey(pt => pt.PopularTagId);
    }
}

public class CategoryMapping : BaseEntityMapping<Category>
{
    public override void Configure(EntityTypeBuilder<Category> builder)
    {
        base.Configure(builder);
        builder
            .HasKey(x => x.Id);
        //  Configure the relationship between Post and Category
        builder
            .HasMany(c => c.Posts)      // -> bir kategorinin, birden fazla postu vardır
            .WithOne(p => p.Category)   // -> bir postun bir kategorisi vardır  - p => p.Category bu alan opsiyonel
            .HasForeignKey(p => p.CategoryId);


        //  Configure self-referencing relationship for Category
        builder
            .HasOne(c => c.ParentCategory)                // Bir kategori bir üst kategoriye sahip olabilir
            .WithMany(c => c!.SubCategories)              // Bir üst kategorinin birçok alt kategorisi olabilir
            .HasForeignKey(c => c.ParentCategoryId)       // ParentCategoryId, alt kategorinin üst kategorisini belirtir
            .OnDelete(DeleteBehavior.Restrict);           // Eğer alt kategoriler varsa, üst kategori silinmesin

        builder
            .HasOne(c => c.ParentCategory)                // Bir kategori bir üst kategoriye sahip olabilir
            .WithMany(c => c!.SubCategories)              // Bir üst kategorinin birçok alt kategorisi olabilir
            .HasForeignKey(c => c.ParentCategoryId)       // ParentCategoryId, alt kategorinin üst kategorisini belirtir
            .OnDelete(DeleteBehavior.Restrict);


    }
}
