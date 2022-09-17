using AutoMapper;
using AutoMapper.QueryableExtensions;
using JT.Application.Places.Queries;
using JT.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JT.Application.Reviews.Queries;

public record GetReviewsForPlaceQuery(int PlaceId) : IRequest<ReviewsDto>;

public class GetReviewsForPlaceQueryHandler : IRequestHandler<GetReviewsForPlaceQuery, ReviewsDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetReviewsForPlaceQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ReviewsDto> Handle(GetReviewsForPlaceQuery request, CancellationToken cancellationToken)
    {
        var response = new ReviewsDto();

        response.Place = await _context.Places
            .Where(p => p.Id == request.PlaceId)
            .ProjectTo<PlaceBriefDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        response.Reviews = await _context.Reviews
            .Where(r => r.PlaceId == request.PlaceId)
            .ProjectTo<ReviewDto>(_mapper.ConfigurationProvider)
            .ToListAsync();

        return response;
    }
}
