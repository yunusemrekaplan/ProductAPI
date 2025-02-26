using ProductAPI.Constants;

namespace ProductAPI.Entities.DTO.Catalog;

public class ProductViewModel
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string Barcode { get; set; }
    public int Quantity { get; set; }
    public string? ImageUrl { get; set; }
    public Carat Carat { get; set; }
    public decimal Fineness { get; set; }
    public decimal LaborCostMilyem { get; set; }
    public decimal MetalWeight { get; set; }
    public ProfitType ProfitType { get; set; }
    public decimal ProfitValue { get; set; }
    public int BrandId { get; set; }
    public string? BrandName { get; set; }
    public int ProductModelId { get; set; }
    public string? ProductModelName { get; set; }
} 