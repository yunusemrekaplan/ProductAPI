using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductAPI.Constants;
using ProductAPI.Data;
using ProductAPI.Entities.DTO.Identity;
using ProductAPI.Entities.Extensions;

namespace ProductAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(ApplicationDbContext context) : ControllerBase
    {
        // GET: api/user
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserViewModel>>> GetUsers()
        {
            return await context.Users
                .AsNoTracking()
                .Include(u => u.Role)
                .Select(u => u.ToUserViewModel())
                .ToListAsync();
        }

        // GET: api/user/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<UserViewModel>> GetUser(int id)
        {
            var user = await context.Users
                .AsNoTracking()
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
                return NotFound(ErrorMessages.UserNotFound);

            return user.ToUserViewModel();
        }

        // POST: api/user
        [HttpPost]
        public async Task<ActionResult<UserViewModel>> CreateUser(UserCreateModel model)
        {
            if (await context.Users.AnyAsync(u => u.Email == model.Email))
                return BadRequest(ErrorMessages.EmailAlreadyExists);

            var role = await context.Roles.FindAsync(model.RoleId);
            
            if (role == null)
                return BadRequest(ErrorMessages.RoleNotFound);

            var user = model.ToUser();
            context.Users.Add(user);
            await context.SaveChangesAsync();

            user.Role = role;

            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user.ToUserViewModel());
        }

        // PUT: api/user/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateUser(int id, UserUpdateModel model)
        {
            if (id != model.Id)
                return BadRequest();

            var user = await context.Users.FindAsync(id);
            if (user == null)
                return NotFound(ErrorMessages.UserNotFound);

            model.ToUser(user);
            await context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/user/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await context.Users.FindAsync(id);
            if (user == null)
                return NotFound(ErrorMessages.UserNotFound);

            context.Users.Remove(user);
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}