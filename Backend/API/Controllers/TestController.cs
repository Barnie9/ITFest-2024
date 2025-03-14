using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("[controller]")]
[ApiController]
public class TestController(
    RequestContext requestContext
    ) : ControllerBase
{
    [HttpGet("no-auth-test")]
    public ActionResult NoAuthTest()
    {
        return Ok("NoAuthTest");
    }

    [HttpGet("auth-test")]
    [Authorize]
    public ActionResult AuthTest()
    {
        return Ok("AuthTest");
    }

    [HttpGet("user-test")]
    [Authorize(Roles = "User")]
    public ActionResult UserTest()
    {
        return Ok("UserTest");
    }

    [HttpGet("admin-test")]
    [Authorize(Roles = "Admin")]
    public ActionResult AdminTest()
    {
        return Ok("AdminTest");
    }
}