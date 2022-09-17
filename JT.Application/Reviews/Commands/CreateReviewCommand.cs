using JT.Domain.Entities;
using MediatR;

namespace JT.Application.Reviews.Commands;

public record CreateReviewCommand(int PlaceId, int Stars, string Description) : IRequest<int>;

public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateReviewCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
    {
        var review = new Review
        {
            PlaceId = request.PlaceId,
            Stars = request.Stars,
            Description = request.Description
        };

        _context.Reviews.Add(review);

        await _context.SaveChangesAsync(cancellationToken);

        return review.Id;
    }
}