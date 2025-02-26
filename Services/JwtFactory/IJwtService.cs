namespace ProductAPI.Services.JwtFactory;

public interface IJwtService
{
    string GenerateAccessToken(Entities.Schemas.IdentitySchema.User user);
}