using ProductAPI.Constants;

namespace ProductAPI.Entities.DTO.Catalog;

public class ProductModelViewModel
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public Carat? DefaultCarat { get; set; }
    public decimal? DefaultLaborCostMilyem { get; set; }
    public ProfitType? DefaultProfitType { get; set; }
    public decimal? DefaultProfitValue { get; set; }
    public int BrandId { get; set; }
    public string? BrandName { get; set; }
    public int ProductCount { get; set; }
} 