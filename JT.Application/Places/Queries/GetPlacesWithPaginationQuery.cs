using AutoMapper;
using AutoMapper.QueryableExtensions;
using JT.Application.Common.Mappings;
using JT.Application.Common.Models;
using MediatR;

namespace JT.Application.Places.Queries;

public record GetPlacesWithPaginationQuery : IRequest<PaginatedList<PlaceBriefDto>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetPlacesWithPaginationQueryHandler : IRequestHandler<GetPlacesWithPaginationQuery, PaginatedList<PlaceBriefDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetPlacesWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<PlaceBriefDto>> Handle(GetPlacesWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.Places
            .OrderBy(x => x.Title)
            .ProjectTo<PlaceBriefDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}