using System.ComponentModel.DataAnnotations;
using ProductAPI.Entities.Schemas.IdentitySchema;

namespace ProductAPI.Entities.DTO.Identity
{
    public class UserCreateModel
    {
        [Required]
        [MaxLength(100)]
        public required string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public required string Surname { get; set; }

        [Required]
        [MaxLength(100)]
        public required string Username { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        public required string Password { get; set; }

        [Required]
        public required int RoleId { get; set; }

        public DateTime? CreatedAt { get; set; }
        
        public DateTime? LastUpdatedAt { get; set; }
        
        public int? CreatedById { get; set; }
        
        public int? LastUpdatedId { get; set; }
        
        public UserViewModel? CreatedBy { get; set; }
        
        public UserViewModel? LastUpdatedBy { get; set; }
    }
}