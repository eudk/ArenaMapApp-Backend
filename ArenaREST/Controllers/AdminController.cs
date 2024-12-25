using ArenaREST.Models;
using ArenaREST.Services;
using Microsoft.AspNetCore.Mvc;

namespace ArenaREST.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly AdminService _adminService;

        public AdminController(AdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AdminLoginModel loginModel)
        {
            var admin = await _adminService.AuthenticateAsync(loginModel.Username, loginModel.Password);

            if (admin == null)
            {
                return Unauthorized(new { Message = "Invalid credentials" });
            }

            return Ok(new { Message = "Login successful", Admin = admin.Username });
        }
    }
}

public class AdminLoginModel
{
    public string Username { get; set; }
    public string Password { get; set; }
}
