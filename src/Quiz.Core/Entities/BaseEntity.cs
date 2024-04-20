using System.Linq.Expressions;

namespace Quiz.Core.Entities;

public class BaseEntity
{
    public int Id { get; set; }
    public bool IsDeactive { get; set; } = false;
    public DateTime CreatedDate { get; set; }= DateTime.Now;
    public DateTime UpdatedDate { get; set; }=DateTime.Now;
}








