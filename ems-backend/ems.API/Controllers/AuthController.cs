using ems.Common.Helper;
using ems.Common.model.Auth;
using ems.Core.Contract.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ems.API.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IServiceManager _serviceManager;

    public AuthController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    /// <summary>
    /// Login to generate access and refresh token
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login(Login model)
    {
        var response = await _serviceManager.AuthService.Login(model);
        return Ok(response);
    }

    /// <summary>
    /// Register user
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<IActionResult> Register(Register model)
    {
        var response = await _serviceManager.AuthService.Register(model);
        return Ok(response);
    }

    /// <summary>
    /// Update profile
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [AllowAnonymous]
    [HttpPut("update-profile")]
    public async Task<IActionResult> UpdateEmployee(int id, RegisterDto model)
    {
        return Ok(await _serviceManager.AuthService.UpdateRegistration(id, model));
    }

    /// <summary>
    /// Based on access and refresh token, API will return new access and refresh token
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [AllowAnonymous]
    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshToken(LoginResponse model)
    {
        var response = await _serviceManager.AuthService.RefreshToken(model);
        return Ok(response);
    }

    /// <summary>
    /// Get all users 
    /// </summary>
    /// <returns></returns>
    [AllowAnonymous]
    [HttpGet("user-list")]
    public async Task<IActionResult> GetUserList(string? searchingParams, [FromQuery] SortingParams sortingParams)
    {
        var response = await _serviceManager.AuthService.UserList(searchingParams, sortingParams);
        return Ok(response);
    }

    /// <summary>
    /// Get specific user after providing token
    /// </summary>
    /// <param name="userid"></param>
    /// <returns></returns>
    [AllowAnonymous]
    [HttpGet("user/{userid}")]
    public async Task<IActionResult> GetUserById(int userid)
    {
        var response = await _serviceManager.AuthService.GetUser(userid);
        return Ok(response);
    }

    /// <summary>
    /// Delete profile
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [AllowAnonymous]
    [HttpDelete("delete-profile")]
    public async Task<IActionResult> DeleteProfile(int id)
    {
        return Ok(await _serviceManager.AuthService.DeleteRegistration(id));
    }
}
