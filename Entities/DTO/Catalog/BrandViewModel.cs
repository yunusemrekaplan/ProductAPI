namespace ProductAPI.Entities.DTO.Catalog;

public class BrandViewModel
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public int ProductModelCount { get; set; }
} 