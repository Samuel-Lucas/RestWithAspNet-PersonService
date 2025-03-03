using ApiPersonService.Business;
using ApiPersonService.Data.VO;
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
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
        if (user is null) return BadRequest("Invalid client request");

        var token = _loginBusiness.ValidateCredentials(user);

        if (token is null) return Unauthorized("User is not authorized to access");

        return Ok(token);
    }

    [HttpPost]
    [Route("refresh")]
    public IActionResult Refresh([FromBody] TokenVO tokenVo)
    {
        if (tokenVo is null) return BadRequest("Invalid client request");

        var token = _loginBusiness.ValidateCredentials(tokenVo);

        if (token is null) return BadRequest("Invalid client request");

        return Ok(token);
    }

    [HttpGet]
    [Route("revoke")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public IActionResult Revoke()
    {
        var userName = User.Identity!.Name;
        var result = _loginBusiness.RevokeToken(userName!);

        if (!result) return BadRequest("Invalid client request");

        return NoContent();
    }
}