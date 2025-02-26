using ProductAPI.Constants;
using ProductAPI.Entities.Schemas.Infrastructure;

namespace ProductAPI.Entities.Schemas.CatalogSchema;

public class ProductModel : AuditableEntity
{
    public required string Name { get; set; }
    
    public string? Description { get; set; }
    
    public Carat? DefaultCarat { get; set; }
    
    public decimal? DefaultLaborCostMilyem { get; set; }
    
    public ProfitType? DefaultProfitType { get; set; }
    
    public decimal? DefaultProfitValue { get; set; }
    
    public required int BrandId { get; set; }
    
    public Brand? Brand { get; set; }
    
    public ICollection<Product>? Products { get; set; }
}