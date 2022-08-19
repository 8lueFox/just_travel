using JT.Application.Common.Exceptions;
using JT.Domain.Events;
using MediatR;

namespace JT.Application.Places.Commands.DeletePlace;

public record DeletePlaceCommand(int Id) : IRequest;

public class DeletePlaceCommandHandler : IRequestHandler<DeletePlaceCommand>
{
    private readonly IApplicationDbContext _context;

    public DeletePlaceCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeletePlaceCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Places
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity is null)
            throw new NotFoundException(nameof(Places), request.Id);

        _context.Places.Remove(entity);

        entity.AddDomainEvent(new PlaceDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
