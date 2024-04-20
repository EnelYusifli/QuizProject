using Microsoft.AspNetCore.Http;

namespace Quiz.Business.DTOs;

public class BlogPutDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Desc { get; set; }
    public IFormFile ImageFile { get; set; }

    public bool IsDeactive { get; set; }
}
