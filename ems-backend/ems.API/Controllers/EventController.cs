using ems.Common.Helper;
using ems.Common.model.Event;
using ems.Core.Contract.Service;
using Microsoft.AspNetCore.Mvc;

namespace ems.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventController : ControllerBase
{
    private readonly IServiceManager _serviceManager;

    public EventController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
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
        return Ok(await _serviceManager.EventService.GetEvent(searchingParams, sortingParams, isCompleted));
    }

    /// <summary>
    /// get the event detail by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetEvent(int id)
    {
        return Ok(await _serviceManager.EventService.GetEventByIdAsync(id));
    }

    /// <summary>
    /// Add event
    /// </summary>
    /// <param name="addEventDto"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> AddEvent([FromForm] AddEventDto addEventDto)
    {
        return Ok(await _serviceManager.EventService.AddEventAsync(addEventDto));
    }

    /// <summary>
    /// Update event
    /// </summary>
    /// <param name="id"></param>
    /// <param name="addEventDto"></param>
    /// <returns></returns>
    [HttpPut]
    public async Task<IActionResult> UpdateEvent(int id,[FromForm] AddEventDto addEventDto)
    {
        return Ok(await _serviceManager.EventService.UpdateEventAsync(id, addEventDto));
    }

    /// <summary>
    /// Delete event
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete]
    public async Task<IActionResult> DeleteEvent(int id)
    {
        return Ok(await _serviceManager.EventService.DeleteEventAsync(id));
    }
}