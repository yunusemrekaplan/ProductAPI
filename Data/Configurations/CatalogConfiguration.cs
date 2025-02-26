using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductAPI.Entities.Schemas.CatalogSchema;
using ProductAPI.Extensions;

namespace ProductAPI.Data.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products", "Catalog");
        builder.HasKey(p => p.Id);
        
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(100);
        
        builder.Property(p => p.Description)
            .HasMaxLength(500);
        
        builder.Property(p => p.Barcode)
            .IsRequired()
            .HasMaxLength(50);
        
        builder.Property(p => p.Quantity)
            .IsRequired();
        
        builder.Property(p => p.ImageUrl)
            .HasMaxLength(250);
        
        builder.Property(p => p.Carat)
            .IsRequired();
        
        builder.Property(p => p.Fineness)
            .IsRequired()
            .HasPrecision(18, 2);
        
        builder.Property(p => p.LaborCostMilyem)
            .IsRequired()
            .HasPrecision(18, 2);
        
        builder.Property(p => p.MetalWeight)
            .IsRequired()
            .HasPrecision(18, 2);
        
        builder.Property(p => p.ProfitType)
            .IsRequired();
        
        builder.Property(p => p.ProfitValue)
            .IsRequired()
            .HasPrecision(18, 2);
        
        builder.HasOne(p => p.Brand)
            .WithMany()
            .HasForeignKey(p => p.BrandId);
        
        builder.HasOne(p => p.ProductModel)
            .WithMany(m => m.Products)
            .HasForeignKey(p => p.ProductModelId)
            .OnDelete(DeleteBehavior.NoAction);
        
        builder.ConfigureAuditableEntity();
    }
}

public class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.ToTable("Brands", "Catalog");
        builder.HasKey(b => b.Id);
        
        builder.Property(b => b.Name)
            .IsRequired()
            .HasMaxLength(100);
        
        builder.Property(b => b.Description)
            .HasMaxLength(500);
        
        builder.HasMany(b => b.ProductModels)
            .WithOne(m => m.Brand)
            .HasForeignKey(m => m.BrandId);
        
        builder.ConfigureAuditableEntity();
    }
}


public class ProductModelConfiguration : IEntityTypeConfiguration<ProductModel>
{
    public void Configure(EntityTypeBuilder<ProductModel> builder)
    {
        builder.ToTable("ProductModels", "Catalog");
        builder.HasKey(c => c.Id);
        
        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100);
        
        builder.Property(c => c.Description)
            .HasMaxLength(500);
        
        builder.Property(c => c.DefaultLaborCostMilyem)
            .HasPrecision(18, 2);
        
        builder.Property(c => c.DefaultProfitValue)
            .HasPrecision(18, 2);
        
        builder.HasOne(m => m.Brand)
            .WithMany(b => b.ProductModels)
            .HasForeignKey(m => m.BrandId);
        
        builder.ConfigureAuditableEntity();
    }
}