using Microsoft.EntityFrameworkCore;
using Quiz.Core.Entities;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Quiz.Core.Repositories;

public interface IBlogRepository
{
    DbSet<Blog> Table { get;}
    Task<IEnumerable<Blog>> GetAllAsync(Expression<Func<Blog, bool>>? expression);
    Task<Blog> GetByIdAsync(int id);
    Task CreateAsync(Blog blog);
    void Delete(Blog blog);
    Task<int> CommitAsync();
}
