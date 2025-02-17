using ApiPersonService.Business;
using ApiPersonService.Data.VO;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace ApiPersonService.Controllers;

[ApiVersion("1")]
[Route("api/[controller]/v{version:apiVersion}")]
[ApiController]
public class AuthController : ControllerBase
{
    private ILoginBusiness _loginBusiness;

    public AuthController(ILoginBusiness loginBusiness)
    {
        _loginBusiness = loginBusiness;
    }

    [HttpPost]
    [Route("signin")]
    public IActionResult Signin([FromBody] UserVO user)
    {
        if (user == null) return BadRequest("Invalid client request");

        var token = _loginBusiness.ValidateCredentials(user);

        if (token == null) return Unauthorized("User is not authorized to access");

        return Ok(token);
    }
}