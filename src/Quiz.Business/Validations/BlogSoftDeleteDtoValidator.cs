using FluentValidation;
using Quiz.Business.DTOs;

namespace Quiz.Business.Validations;

public class BlogSoftDeleteDtoValidator:AbstractValidator<BlogSoftDeleteDto>
{
    public BlogSoftDeleteDtoValidator()
    {
        RuleFor(x => x.Id).NotNull().NotEmpty().GreaterThan(0);
        RuleFor(x => x.IsDeactive).NotNull().NotEmpty();
    }
}
