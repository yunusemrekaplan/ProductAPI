namespace ProductAPI.Entities.DTO.Catalog;

public class BrandUpdateModel
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
} 