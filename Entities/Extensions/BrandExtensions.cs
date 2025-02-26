using ProductAPI.Entities.DTO.Catalog;
using ProductAPI.Entities.Schemas.CatalogSchema;

namespace ProductAPI.Entities.Extensions;

public static class BrandExtensions
{
    public static BrandViewModel ToBrandViewModel(this Brand brand)
    {
        return new BrandViewModel
        {
            Id = brand.Id,
            Name = brand.Name,
            Description = brand.Description,
            ProductModelCount = brand.ProductModels?.Count ?? 0
        };
    }

    public static Brand ToBrand(this BrandCreateModel model)
    {
        return new Brand
        {
            Name = model.Name,
            Description = model.Description
        };
    }

    public static void ToBrand(this BrandUpdateModel model, Brand brand)
    {
        brand.Name = model.Name;
        brand.Description = model.Description;
    }
} 