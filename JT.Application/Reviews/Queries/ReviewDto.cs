using JT.Application.Common.Mappings;
using JT.Domain.Entities;

namespace JT.Application.Reviews.Queries;

public class ReviewDto : IMapFrom<Review>
{
    public int Stars { get; set; }

    public string? Description { get; set; }
}
