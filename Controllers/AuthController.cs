using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductAPI.Constants;
using ProductAPI.Data;
using ProductAPI.Entities.DTO.Auth.Requests;
using ProductAPI.Entities.DTO.Auth.Responses;
using ProductAPI.Entities.Schemas.IdentitySchema;
using ProductAPI.Services.JwtFactory;

namespace ProductAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(ApplicationDbContext context, IJwtService jwtService) : ControllerBase
    {
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Username == loginRequest.Username);

            if (user == null || !BCrypt.Net.BCrypt.Verify(loginRequest.Password, user.PasswordHash))
                return BadRequest(new { message = ErrorMessages.InvalidUsernameOrPassword });

            var accessToken = jwtService.GenerateAccessToken(user);
            var refreshToken = JwtService.GenerateRefreshToken();

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiry = DateTime.UtcNow.AddMinutes(30);

            await context.SaveChangesAsync();

            return Ok(new LoginResponse
            {
                Id = user.Id,
                UserName = user.Username,
                AccessToken = accessToken,
                RefreshToken = refreshToken
            });
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromBody] string refreshToken)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);

            if (user == null || user.RefreshTokenExpiry < DateTime.UtcNow)
                return Unauthorized(new { message = ErrorMessages.InvalidRefreshToken });

            var newAccessToken = jwtService.GenerateAccessToken(user);
            var newRefreshToken = JwtService.GenerateRefreshToken();

            user.RefreshToken = newRefreshToken;
            user.RefreshTokenExpiry = DateTime.UtcNow.AddMinutes(30);

            await context.SaveChangesAsync();

            return Ok(new RefreshResponse
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken
            });
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest)
        {
            var existingUser = await context.Users.FirstOrDefaultAsync(u => u.Username == registerRequest.Username);

            if (existingUser != null)
                return BadRequest(new { message = ErrorMessages.UsernameAlreadyExists });

            var user = new User
            {
                Username = registerRequest.Username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(registerRequest.Password),
                Email = registerRequest.Email,
                Name = registerRequest.Name,
                Surname = registerRequest.Surname,
                RoleId = registerRequest.RoleId
            };

            context.Users.Add(user);
            await context.SaveChangesAsync();

            return Ok(new { message = "User registered successfully" });
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout([FromBody] string refreshToken)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);

            if (user == null)
                return NotFound(new { message = ErrorMessages.UserNotFound });

            user.RefreshToken = null;
            user.RefreshTokenExpiry = null;

            await context.SaveChangesAsync();

            return Ok(new { message = "Logged out successfully" });
        }
    }
}