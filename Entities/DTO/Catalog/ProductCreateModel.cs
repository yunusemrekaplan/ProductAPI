using ProductAPI.Constants;

namespace ProductAPI.Entities.DTO.Catalog;

public class ProductCreateModel
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
    public required int ProductModelId { get; set; }
} 