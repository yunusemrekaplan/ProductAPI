using System.Security.Claims;
using ProductAPI.Extensions;

namespace ProductAPI.Services.User;

public class UserService(IHttpContextAccessor httpContextAccessor) : IUserService
{
    public int? GetCurrentUserId()
    {
        return httpContextAccessor.HttpContext?.User.GetUserId();
    }
}