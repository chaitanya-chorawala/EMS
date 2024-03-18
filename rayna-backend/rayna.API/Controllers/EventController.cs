using rayna.Common.Helper;
using rayna.Common.model.Rayna;
using rayna.Core.Contract.Service;
using Microsoft.AspNetCore.Mvc;

namespace rayna.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventController : ControllerBase
{
    private readonly IEventService _eventService;

    public EventController(IEventService eventService)
    {
        _eventService = eventService;
    }
    /// <summary>
    /// get the event detail
    /// </summary>
    /// <param name="searchingParams"></param>
    /// <param name="sortingParams"></param>
    /// <param name="status"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetEvent(string? searchingParams, [FromQuery] SortingParams sortingParams, bool isCompleted = false)
    {
        return Ok(await _eventService.GetEvent(searchingParams, sortingParams, isCompleted));
    }
    /// <summary>
    /// register event
    /// </summary>
    /// <param name="addEventDto"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> AddEvent([FromForm] AddEventDto addEventDto)
    {
        return Ok(await _eventService.AddEventAsync(addEventDto));
    }
}