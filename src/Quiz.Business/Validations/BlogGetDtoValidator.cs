using FluentValidation;
using Quiz.Business.DTOs;

namespace Quiz.Business.Validations;

public class BlogGetDtoValidator:AbstractValidator<BlogGetDto>
{
    public BlogGetDtoValidator()
    {
        RuleFor(x => x.Title).MaximumLength(500).WithMessage("Max length is 500").MinimumLength(5).WithMessage("Max length is 5");
        RuleFor(x => x.Desc).MaximumLength(1000).WithMessage("Max length is 1000").MinimumLength(20).WithMessage("Max length is 20");
        RuleFor(x => x.ImageUrl).MaximumLength(100).WithMessage("Max length is 100");
    }
}
