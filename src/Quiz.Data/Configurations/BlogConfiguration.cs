using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quiz.Core.Entities;

namespace Quiz.Data.Configurations;

public class BlogConfiguration : IEntityTypeConfiguration<Blog>
{
    public void Configure(EntityTypeBuilder<Blog> builder)
    {
        builder.Property(x => x.Title).IsRequired().HasMaxLength(500);
        builder.Property(x => x.Desc).IsRequired().HasMaxLength(1000);
        builder.Property(x => x.ImageUrl).IsRequired().HasMaxLength(100);
    }
}
