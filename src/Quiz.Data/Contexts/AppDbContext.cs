using Microsoft.EntityFrameworkCore;
using Quiz.Core.Entities;
using Quiz.Data.Configurations;
using System.Reflection;

namespace Quiz.Data.Contexts;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BlogConfiguration).Assembly);
    }
    public DbSet<Blog> Blogs { get; set; }
}
