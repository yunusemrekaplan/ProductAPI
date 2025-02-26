using ProductAPI.Entities.DTO.Catalog;
using ProductAPI.Entities.Schemas.CatalogSchema;

namespace ProductAPI.Entities.Extensions;

public static class ProductModelExtensions
{
    public static ProductModelViewModel ToProductModelViewModel(this ProductModel productModel)
    {
        return new ProductModelViewModel
        {
            Id = productModel.Id,
            Name = productModel.Name,
            Description = productModel.Description,
            DefaultCarat = productModel.DefaultCarat,
            DefaultLaborCostMilyem = productModel.DefaultLaborCostMilyem,
            DefaultProfitType = productModel.DefaultProfitType,
            DefaultProfitValue = productModel.DefaultProfitValue,
            BrandId = productModel.BrandId,
            BrandName = productModel.Brand?.Name,
            ProductCount = productModel.Products?.Count ?? 0
        };
    }

    public static ProductModel ToProductModel(this ProductModelCreateModel model)
    {
        return new ProductModel
        {
            Name = model.Name,
            Description = model.Description,
            DefaultCarat = model.DefaultCarat,
            DefaultLaborCostMilyem = model.DefaultLaborCostMilyem,
            DefaultProfitType = model.DefaultProfitType,
            DefaultProfitValue = model.DefaultProfitValue,
            BrandId = model.BrandId
        };
    }

    public static void ToProductModel(this ProductModelUpdateModel model, ProductModel productModel)
    {
        productModel.Name = model.Name;
        productModel.Description = model.Description;
        productModel.DefaultCarat = model.DefaultCarat;
        productModel.DefaultLaborCostMilyem = model.DefaultLaborCostMilyem;
        productModel.DefaultProfitType = model.DefaultProfitType;
        productModel.DefaultProfitValue = model.DefaultProfitValue;
        productModel.BrandId = model.BrandId;
    }
} 