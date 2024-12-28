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
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            var isValid = await _adminService.VerifyAdminLogin(loginRequest.Username, loginRequest.Password);
            if (!isValid) return Unauthorized(new { Message = "Invalid username or password" });

            // Update last login timestamp
            await _adminService.UpdateLastLogin(loginRequest.Username);

            return Ok(new { Message = "Login successful" });
        }

       // [HttpPost("create")]
      //  public async Task<IActionResult> CreateAdmin([FromBody] CreateAdminRequest request)
      //  {
      //      var success = await _adminService.AddAdmin(request.Username, request.Password);
      //      if (!success) return BadRequest(new { Message = "Failed to create admin" });

          //  return Ok(new { Message = "Admin created successfully" });
        }
    }

    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class CreateAdminRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
