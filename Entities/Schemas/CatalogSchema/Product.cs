using ProductAPI.Constants;
using ProductAPI.Entities.Schemas.Infrastructure;

namespace ProductAPI.Entities.Schemas.CatalogSchema;

public class Product : AuditableEntity
{
    public required string Name { get; set; }
    
    public required string Description { get; set; }
    
    public required string Barcode { get; set; }

    public required int Quantity { get; set; }
    
    public string? ImageUrl { get; set; }
    
    public required Carat Carat { get; set; }
    
    public required decimal Fineness { get; set; }
    
    public required decimal LaborCostMilyem { get; set; }
    
    public required decimal MetalWeight { get; set; }
    
    public required ProfitType ProfitType { get; set; }
    
    public required decimal ProfitValue { get; set; }
    
    public required int BrandId { get; set; }
    
    public Brand? Brand { get; set; }
    
    public required int ProductModelId { get; set; }
    
    public ProductModel? ProductModel { get; set; }
}