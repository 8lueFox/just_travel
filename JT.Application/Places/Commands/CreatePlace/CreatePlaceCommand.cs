using JT.Domain.Entities;
using JT.Domain.Events;
using MediatR;

namespace JT.Application.Places.Commands.CreatePlace;

public record CreatePlaceCommand : IRequest<int>
{
    public string? Title { get; init; }
}

public class CreatePlaceCommandHandler : IRequestHandler<CreatePlaceCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreatePlaceCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreatePlaceCommand request, CancellationToken cancellationToken)
    {
        var entity = new Place
        {
            Title = request.Title
        };

        entity.AddDomainEvent(new PlaceAddedEvent(entity));

        _context.Places.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}