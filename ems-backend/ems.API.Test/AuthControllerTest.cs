using ems.API.Controllers;
using ems.Common.ExceptionHandler;
using ems.Common.Helper;
using ems.Common.model;
using ems.Common.model.Auth;
using ems.Core.Contract.Service;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace ems.API.Test;

public class AuthControllerTest
{
    private readonly Mock<IAuthService> authServiceMock;
    private readonly AuthController controller;

    public AuthControllerTest()
    {
        authServiceMock = new Mock<IAuthService>();
        controller = new AuthController(authServiceMock.Object);
    }

    #region Login API
    [Fact]
    public async Task Login_Must_Pass()
    {
        authServiceMock.Setup(service => service.Login(It.IsAny<Login>()))
            .ReturnsAsync(new LoginResponse());

        var result = await controller.Login(new Login());
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async Task Login_Handle_NotFound_Exception()
    {
        authServiceMock.Setup(service => service.Login(It.IsAny<Login>()))
            .ThrowsAsync(new NotFoundException(""));

        await Assert.ThrowsAnyAsync<NotFoundException>(async () => await controller.Login(null));
    }

    [Fact]
    public async Task Login_Handle_InternalServer_Exception()
    {
        authServiceMock.Setup(service => service.Login(It.IsAny<Login>()))
            .ThrowsAsync(new Exception());

        await Assert.ThrowsAnyAsync<Exception>(async () => await controller.Login(null));
    }
    #endregion

    #region GetUserList API
    [Fact]
    public async Task GetUserList_Must_Pass()
    {
        authServiceMock.Setup(service => service.UserList(It.IsAny<string>(), It.IsAny<SortingParams>()))
            .ReturnsAsync(new PaginationResponse<RegistrationResponse>());

        var result = await controller.GetUserList("", new SortingParams());

        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async Task GetUserList_Handle_InternalServer_Exception()
    {
        authServiceMock.Setup(service => service.UserList(It.IsAny<string>(), It.IsAny<SortingParams>()))
            .ThrowsAsync(new Exception());

        await Assert.ThrowsAnyAsync<Exception>(async () => 
            await controller.GetUserList("", new SortingParams()));
    }
    #endregion
}
