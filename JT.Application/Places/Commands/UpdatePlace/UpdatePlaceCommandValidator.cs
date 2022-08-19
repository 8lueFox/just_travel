using FluentValidation;

namespace JT.Application.Places.Commands.UpdatePlace;

public class UpdatePlaceCommandValidator : AbstractValidator<UpdatePlaceCommand>
{
    public UpdatePlaceCommandValidator()
    {
        RuleFor(v => v.Title)
            .MaximumLength(300)
            .NotEmpty();

        RuleFor(v => v.Description)
            .MinimumLength(50)
            .MaximumLength(1000);
    }
}
