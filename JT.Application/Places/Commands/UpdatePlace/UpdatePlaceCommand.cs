using JT.Application.Common.Exceptions;
using JT.Domain.Entities;
using MediatR;

namespace JT.Application.Places.Commands.UpdatePlace;

public record UpdatePlaceCommand : IRequest
{
    public int Id { get; init; }

    public string? Title { get; init; }

    public string? Description { get; set; }
}

public class UpdatePlaceCommandHandler : IRequestHandler<UpdatePlaceCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdatePlaceCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdatePlaceCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Places
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity is null)
            throw new NotFoundException(nameof(Place), request.Id);

        entity.Title = request.Title;
        entity.Description = request.Description;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
