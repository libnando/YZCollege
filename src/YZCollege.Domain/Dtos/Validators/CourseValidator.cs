using FluentValidation;
using YZCollege.Domain.Dtos.Request;

namespace YZCollege.Domain.Dtos.Validators
{
    public class CoursePostValidator : AbstractValidator<CoursePostRequestDto>
    {
        public CoursePostValidator()
        {
            RuleFor(c => c.Name).NotEmpty().NotNull().WithMessage("Name is required");
            RuleFor(c => c.Duration).InclusiveBetween(1, 60);
        }
    }
}
