namespace Quiz.Business.DTOs;

public class BlogGetDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Desc { get; set; }
    public string ImageUrl { get; set; }
    public bool IsDeactive { get; set; }
    public DateTime CreatedDate { get; set; }
}
