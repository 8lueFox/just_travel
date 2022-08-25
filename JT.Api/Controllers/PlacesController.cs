using JT.Application.Common.Models;
using JT.Application.Places.Commands.CreatePlace;
using JT.Application.Places.Queries;
using Microsoft.AspNetCore.Mvc;

namespace JT.Api.Controllers;

public class PlacesController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedList<PlaceBriefDto>>> GetTodoItemsWithPagination([FromQuery] GetPlacesWithPaginationQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreatePlaceCommand command)
    {
        return await Mediator.Send(command);
    }
}
