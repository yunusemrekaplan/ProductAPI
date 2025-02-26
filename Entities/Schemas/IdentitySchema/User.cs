using System.ComponentModel.DataAnnotations;
using ProductAPI.Entities.Schemas.Infrastructure;

namespace ProductAPI.Entities.Schemas.IdentitySchema
{
    public class User : AuditableEntity
    {
        [MaxLength(50)]
        public required string Name { get; set; }
        
        [MaxLength(50)]
        public required string Surname { get; set; }
        
        [MaxLength(50)]
        public required string Username { get; set; }
        
        [EmailAddress]
        [MaxLength(100)]
        public required string Email { get; set; }
        
        [MaxLength(500)]
        public string? PasswordHash { get; set; }
        
        public int RoleId { get; set; }
        
        public Role? Role { get; set; }
        
        [MaxLength]
        public string? RefreshToken { get; set; }
        
        public DateTime? RefreshTokenExpiry { get; set; }
    }
}