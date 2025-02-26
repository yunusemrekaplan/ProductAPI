using ProductAPI.Entities.Schemas.Infrastructure;

namespace ProductAPI.Entities.Schemas.CatalogSchema;

public class Brand : AuditableEntity
{
    public required string Name { get; set; }
    
    public string? Description { get; set; }
    
    public ICollection<ProductModel>? ProductModels { get; set; }
    
    //public string? ImageUrl { get; set; }
    
}