using System.ComponentModel.DataAnnotations;
using ProductAPI.Entities.Schemas.Infrastructure;

namespace ProductAPI.Entities.Schemas.IdentitySchema;

public class Role : AuditableEntity
{
    [Required]
    [MaxLength(50)]
    public required string Name { get; set; }
    public ICollection<User> Users { get; set; } = new List<User>();
}