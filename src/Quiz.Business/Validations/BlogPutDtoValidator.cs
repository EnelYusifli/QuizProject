using FluentValidation;
using Quiz.Business.DTOs;

namespace Quiz.Business.Validations;

public class BlogPutDtoValidator : AbstractValidator<BlogPutDto>
{
    public BlogPutDtoValidator()
    {
        RuleFor(x => x.Id).NotNull().NotEmpty().GreaterThan(0);
        RuleFor(x => x.Title).NotNull().NotEmpty().MaximumLength(500).WithMessage("Max length is 500").MinimumLength(5).WithMessage("Max length is 5");
        RuleFor(x => x.Desc).NotNull().NotEmpty().MaximumLength(1000).WithMessage("Max length is 1000").MinimumLength(20).WithMessage("Max length is 20");
        RuleFor(x => x.IsDeactive).NotNull().NotEmpty();
    }
}
