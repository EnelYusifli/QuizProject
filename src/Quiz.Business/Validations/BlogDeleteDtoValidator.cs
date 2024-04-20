using FluentValidation;
using Quiz.Business.DTOs;

namespace Quiz.Business.Validations;

public class BlogDeleteDtoValidator:AbstractValidator<BlogDeleteDto>
{
    public BlogDeleteDtoValidator()
    {
        RuleFor(x => x.Id).NotNull().NotEmpty().GreaterThan(0);
    }
}
