using ProductAPI.Entities.Schemas.IdentitySchema;

namespace ProductAPI.Entities.DTO.Identity
{
    public class UserViewModel
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public required string Surname { get; set; }

        public required string Username { get; set; }

        public required string Email { get; set; }

        public required string RoleName { get; set; }

        public DateTime? CreatedAt { get; set; }
        
        public DateTime? LastUpdatedAt { get; set; }
        
        public int? CreatedById { get; set; }
        
        public int? LastUpdatedId { get; set; }
        
        public UserViewModel? CreatedBy { get; set; }
        
        public UserViewModel? LastUpdatedBy { get; set; }
    }
}