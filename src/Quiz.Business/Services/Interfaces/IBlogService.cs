using Quiz.Business.DTOs;
using Quiz.Core.Entities;
using Quiz.Core.Repositories;
using System.Linq.Expressions;

namespace Quiz.Business.Services.Interfaces;

public interface IBlogService
{
    Task Create(BlogPostDto dto);
    Task Update(BlogPutDto dto,int id);
    Task Delete(BlogDeleteDto dto, int id);
    Task SoftDelete(BlogSoftDeleteDto dto,int id);
    Task<IEnumerable<BlogGetDto>> GetAll(Expression<Func<Blog, bool>>? expression);
    Task<BlogGetDto> GetById(int id);
}
