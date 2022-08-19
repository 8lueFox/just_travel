using JT.Application.Common.Mappings;
using JT.Domain.Entities;

namespace JT.Application.Places.Queries;

public class PlaceBriefDto : IMapFrom<Place>
{
    public int Id { get; set; }
    
    public string? Title { get; set; }

    public string? Description { get; set; }
}
