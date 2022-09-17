using FluentValidation;

namespace JT.Application.Reviews.Commands;

public class CreateReviewCommandValidator : AbstractValidator<CreateReviewCommand>
{
    public CreateReviewCommandValidator()
    {
        RuleFor(v => v.PlaceId)
            .NotNull()
            .GreaterThan(0);

        RuleFor(v => v.Stars)
            .NotNull()
            .GreaterThan(0)
            .LessThan(6);

        RuleFor(v => v.Description)
            .NotNull()
            .NotEmpty()
            .MinimumLength(10)
            .MaximumLength(1000);
    }
}
