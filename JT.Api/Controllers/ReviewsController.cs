using JT.Application.Reviews.Commands;
using JT.Application.Reviews.Queries;
using JT.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace JT.Api.Controllers;

public class ReviewsController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<ReviewsDto>> GetReviewsForPlace([FromQuery] GetReviewsForPlaceQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateReviewCommand command)
    {
        return await Mediator.Send(command);
    }
}
