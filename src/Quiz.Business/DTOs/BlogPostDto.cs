using Microsoft.AspNetCore.Http;

namespace Quiz.Business.DTOs;

public class BlogPostDto
{
    public string Title { get; set; }
    public string Desc { get; set; }
    public IFormFile ImageFile { get; set; }

    public bool IsDeactive { get; set; }
}
