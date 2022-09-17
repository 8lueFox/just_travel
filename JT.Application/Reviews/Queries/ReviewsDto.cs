using JT.Application.Places.Queries;

namespace JT.Application.Reviews.Queries;

public class ReviewsDto
{
    public PlaceBriefDto Place { get; set; }

    public IEnumerable<ReviewDto> Reviews { get; set; }
}
