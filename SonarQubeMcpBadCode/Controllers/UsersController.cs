using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SonarDemoMcp.Models;
using SonarDemoMcp.Services;

namespace SonarDemoMcp.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly UserService _service;
    // champ public (code smell)
    public string LastAction;

    public UsersController(UserService service)
    {
        _service = service;
    }

    [HttpGet("{id}")]
    public ActionResult<User> Get(int id)
    {
        // Pas de validation d'entrée (possible bug)
        var user = _service.GetUserById(id);
        // possible null reference (bug)
        return Ok(user.Name.ToUpper());
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest req)
    {
        // Hardcoded secret comparison (security hotspot)
        if (req.Password == "P@ssw0rd!")
        {
            LastAction = "login-success";
            return Ok(new { token = "hardcoded-token-123" }); // hardcoded token
        }
        LastAction = "login-failed";
        return Unauthorized();
    }
}

public class LoginRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
}
