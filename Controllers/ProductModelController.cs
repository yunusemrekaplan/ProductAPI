using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductAPI.Constants;
using ProductAPI.Data;
using ProductAPI.Entities.DTO.Catalog;
using ProductAPI.Entities.Extensions;

namespace ProductAPI.Controllers;

//[Authorize]
[Route("api/[controller]")]
[ApiController]
public class ProductModelController(ApplicationDbContext context) : ControllerBase
{
    // GET: api/productmodel
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductModelViewModel>>> GetProductModels()
    {
        return await context.ProductModels
            .AsNoTracking()
            .Include(pm => pm.Brand)
            .Include(pm => pm.Products)
            .Select(pm => pm.ToProductModelViewModel())
            .ToListAsync();
    }

    // GET: api/productmodel/5
    [HttpGet("{id:int}")]
    public async Task<ActionResult<ProductModelViewModel>> GetProductModel(int id)
    {
        var productModel = await context.ProductModels
            .AsNoTracking()
            .Include(pm => pm.Brand)
            .Include(pm => pm.Products)
            .FirstOrDefaultAsync(pm => pm.Id == id);

        if (productModel == null)
            return NotFound();

        return productModel.ToProductModelViewModel();
    }

    // GET: api/productmodel/brand/5
    [HttpGet("brand/{brandId:int}")]
    public async Task<ActionResult<IEnumerable<ProductModelViewModel>>> GetProductModelsByBrand(int brandId)
    {
        var brand = await context.Brands.FindAsync(brandId);
        if (brand == null)
            return NotFound(ErrorMessages.BrandNotFound);

        return await context.ProductModels
            .AsNoTracking()
            .Include(pm => pm.Brand)
            .Include(pm => pm.Products)
            .Where(pm => pm.BrandId == brandId)
            .Select(pm => pm.ToProductModelViewModel())
            .ToListAsync();
    }

    // POST: api/productmodel
    [HttpPost]
    public async Task<ActionResult<ProductModelViewModel>> CreateProductModel(ProductModelCreateModel model)
    {
        var brand = await context.Brands.FindAsync(model.BrandId);
        if (brand == null)
            return BadRequest(ErrorMessages.BrandNotFound);

        if (await context.ProductModels.AnyAsync(pm => pm.Name == model.Name && pm.BrandId == model.BrandId))
            return BadRequest(ErrorMessages.ProductModelNameExists);

        var productModel = model.ToProductModel();
        context.ProductModels.Add(productModel);
        await context.SaveChangesAsync();

        productModel.Brand = brand;

        return CreatedAtAction(nameof(GetProductModel), new { id = productModel.Id }, productModel.ToProductModelViewModel());
    }

    // PUT: api/productmodel/5
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateProductModel(int id, ProductModelUpdateModel model)
    {
        if (id != model.Id)
            return BadRequest();

        var productModel = await context.ProductModels.FindAsync(id);
        if (productModel == null)
            return NotFound();

        if (await context.ProductModels.AnyAsync(pm => pm.Name == model.Name && pm.BrandId == model.BrandId && pm.Id != id))
            return BadRequest(ErrorMessages.ProductModelNameExists);

        var brand = await context.Brands.FindAsync(model.BrandId);
        if (brand == null)
            return BadRequest(ErrorMessages.BrandNotFound);

        model.ToProductModel(productModel);
        await context.SaveChangesAsync();

        return NoContent();
    }

    // DELETE: api/productmodel/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteProductModel(int id)
    {
        var productModel = await context.ProductModels
            .Include(pm => pm.Products)
            .FirstOrDefaultAsync(pm => pm.Id == id);

        if (productModel == null)
            return NotFound();

        if (productModel.Products?.Any() == true)
            return BadRequest(ErrorMessages.CannotDeleteProductModelWithProducts);

        context.ProductModels.Remove(productModel);
        await context.SaveChangesAsync();

        return NoContent();
    }
}