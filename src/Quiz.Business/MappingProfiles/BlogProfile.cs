using AutoMapper;
using Quiz.Business.DTOs;
using Quiz.Core.Entities;

namespace Quiz.Business.MappingProfiles;

public class BlogProfile:Profile
{
    public BlogProfile()
    {
        CreateMap<BlogGetDto, Blog>().ReverseMap();
        CreateMap<BlogDeleteDto, Blog>().ReverseMap();
        CreateMap<BlogPostDto, Blog>().ReverseMap();
        CreateMap<BlogPutDto, Blog>().ReverseMap();
        CreateMap<BlogSoftDeleteDto, Blog>().ReverseMap();
    }
}
