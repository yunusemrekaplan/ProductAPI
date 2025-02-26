using ProductAPI.Entities.DTO.Catalog;
using ProductAPI.Entities.Schemas.CatalogSchema;

namespace ProductAPI.Entities.Extensions;

public static class ProductExtensions
{
    public static ProductViewModel ToProductViewModel(this Product product)
    {
        return new ProductViewModel
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Barcode = product.Barcode,
            Quantity = product.Quantity,
            ImageUrl = product.ImageUrl,
            Carat = product.Carat,
            Fineness = product.Fineness,
            LaborCostMilyem = product.LaborCostMilyem,
            MetalWeight = product.MetalWeight,
            ProfitType = product.ProfitType,
            ProfitValue = product.ProfitValue,
            BrandId = product.BrandId,
            BrandName = product.Brand?.Name,
            ProductModelId = product.ProductModelId,
            ProductModelName = product.ProductModel?.Name
        };
    }

    public static Product ToProduct(this ProductCreateModel model)
    {
        return new Product
        {
            Name = model.Name,
            Description = model.Description,
            Barcode = model.Barcode,
            Quantity = model.Quantity,
            ImageUrl = model.ImageUrl,
            Carat = model.Carat,
            Fineness = model.Fineness,
            LaborCostMilyem = model.LaborCostMilyem,
            MetalWeight = model.MetalWeight,
            ProfitType = model.ProfitType,
            ProfitValue = model.ProfitValue,
            BrandId = model.BrandId,
            ProductModelId = model.ProductModelId
        };
    }

    public static void ToProduct(this ProductUpdateModel model, Product product)
    {
        product.Name = model.Name;
        product.Description = model.Description;
        product.Barcode = model.Barcode;
        product.Quantity = model.Quantity;
        product.ImageUrl = model.ImageUrl;
        product.Carat = model.Carat;
        product.Fineness = model.Fineness;
        product.LaborCostMilyem = model.LaborCostMilyem;
        product.MetalWeight = model.MetalWeight;
        product.ProfitType = model.ProfitType;
        product.ProfitValue = model.ProfitValue;
        product.BrandId = model.BrandId;
        product.ProductModelId = model.ProductModelId;
    }
} 