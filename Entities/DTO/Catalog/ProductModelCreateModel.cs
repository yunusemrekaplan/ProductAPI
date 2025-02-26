using ProductAPI.Constants;

namespace ProductAPI.Entities.DTO.Catalog;

public class ProductModelCreateModel
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public Carat? DefaultCarat { get; set; }
    public decimal? DefaultLaborCostMilyem { get; set; }
    public ProfitType? DefaultProfitType { get; set; }
    public decimal? DefaultProfitValue { get; set; }
    public required int BrandId { get; set; }
}