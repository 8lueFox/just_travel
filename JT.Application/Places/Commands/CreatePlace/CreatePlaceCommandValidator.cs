using FluentValidation;

namespace JT.Application.Places.Commands.CreatePlace;

public class CreatePlaceCommandValidator : AbstractValidator<CreatePlaceCommand>
{
    public CreatePlaceCommandValidator()
    {
        RuleFor(v => v.Title)
            .MaximumLength(300)
            .NotEmpty();
    }
}
