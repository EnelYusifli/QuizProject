using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Quiz.Business.DTOs;
using Quiz.Business.Helpers.Exceptions;
using Quiz.Business.Helpers.Extensions;
using Quiz.Business.Services.Interfaces;
using Quiz.Core.Entities;
using Quiz.Core.Repositories;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Quiz.Business.Services.Implementations;

public class BlogService : IBlogService
{
    private readonly IBlogRepository _repository;
    private readonly IMapper _mapper;
    private readonly IWebHostEnvironment _env;

    public BlogService(IBlogRepository repository,IMapper mapper,IWebHostEnvironment env)
    {
        _repository = repository;
        _mapper = mapper;
        _env = env;
    }

    public async Task Create(BlogPostDto dto)
    {
        if(dto is null) throw new NotFoundException("Not found");
        Blog blog = new();
        blog=_mapper.Map<Blog>(dto);
        blog.ImageUrl = dto.ImageFile.SaveFile(_env.WebRootPath, "uploads");
        await _repository.CreateAsync(blog);
        await _repository.CommitAsync();
    }

    public async Task Delete(BlogDeleteDto dto, int id)
    {
        Blog blog = await _repository.GetByIdAsync(id);
        if (blog is null) throw new NotFoundException("Not Found");
        if (dto.Id != id) throw new Exception("Ids are not the same");
        FileExtension.DeleteFile(_env.WebRootPath, "uploads",blog.ImageUrl);
        _repository.Delete(blog);
       await  _repository.CommitAsync();
    }

    public async Task<IEnumerable<BlogGetDto>> GetAll(Expression<Func<Blog, bool>>? expression)
    {
        IEnumerable <Blog> blogs =await _repository.GetAllAsync(expression);
        if (blogs is null) throw new NotFoundException("Blog not found");
        IEnumerable<BlogGetDto> dtos = _mapper.Map<IEnumerable<BlogGetDto>>(blogs);
        return dtos;
    }

    public async Task<BlogGetDto> GetById(int id)
    {
        Blog blog = await _repository.GetByIdAsync(id);
        if (blog is null) throw new NotFoundException("Not Found");
        BlogGetDto dto=_mapper.Map<BlogGetDto>(blog);
        return dto;
    }

    public async Task SoftDelete(BlogSoftDeleteDto dto, int id)
    {
        Blog blog = await _repository.GetByIdAsync(id);
        if (blog is null) throw new NotFoundException("Not Found");
        if (dto.Id != id) throw new Exception("Ids are not the same");
        blog.IsDeactive = dto.IsDeactive;
        await _repository.CommitAsync();
    }

    public async Task Update(BlogPutDto dto,int id)
    {
        if (dto.Id != id) throw new Exception("Ids are not the same");
        Blog blog = await _repository.GetByIdAsync(id);
        if (blog is null) throw new NotFoundException("Not Found");
        _mapper.Map(dto,blog);
        if(dto.ImageFile is not null)
        {
            FileExtension.DeleteFile(_env.WebRootPath, "uploads", blog.ImageUrl);
            blog.ImageUrl = dto.ImageFile.SaveFile(_env.WebRootPath, "uploads");
        }
        await _repository.CommitAsync();

    }
}
