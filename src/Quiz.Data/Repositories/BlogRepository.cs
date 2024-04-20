using Microsoft.EntityFrameworkCore;
using Quiz.Core.Entities;
using Quiz.Core.Repositories;
using Quiz.Data.Contexts;
using System.Linq.Expressions;

namespace Quiz.Data.Repositories;

public class BlogRepository : IBlogRepository
{
    private readonly AppDbContext _context;

    
    public BlogRepository(AppDbContext context)
    {
        _context = context;
    }

    public DbSet<Blog> Table => _context.Set<Blog>();  

    public async Task<int> CommitAsync()
    => await _context.SaveChangesAsync();

    public async Task CreateAsync(Blog blog)
    =>await _context.Blogs.AddAsync(blog);

    public void Delete(Blog blog)
    => _context.Blogs.Remove(blog);

    public async Task<IEnumerable<Blog>> GetAllAsync(Expression<Func<Blog, bool>>? expression)
    {
        var query = Table.AsQueryable();
        
        return expression is not null ? await query.Where(expression).ToListAsync() : await query.ToListAsync();
    }

    public async Task<Blog> GetByIdAsync(int id)
    => await _context.Blogs.FindAsync(id);
}
