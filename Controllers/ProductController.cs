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
public class ProductController(ApplicationDbContext context) : ControllerBase
{
    // GET: api/product
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductViewModel>>> GetProducts()
    {
        return await context.Products
            .AsNoTracking()
            .Include(p => p.ProductModel)
            .ThenInclude(pm => pm!.Brand)
            .Select(p => p.ToProductViewModel())
            .ToListAsync();
    }

    // GET: api/product/5
    [HttpGet("{id:int}")]
    public async Task<ActionResult<ProductViewModel>> GetProduct(int id)
    {
        var product = await context.Products
            .AsNoTracking()
            .Include(p => p.ProductModel)
            .ThenInclude(pm => pm!.Brand)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (product == null)
            return NotFound(ErrorMessages.ProductNotFound);

        return product.ToProductViewModel();
    }

    // POST: api/product
    [HttpPost]
    public async Task<ActionResult<ProductViewModel>> CreateProduct(ProductCreateModel model)
    {
        if (await context.Products.AnyAsync(p => p.Name == model.Name))
            return BadRequest(ErrorMessages.ProductNameExists);

        var product = model.ToProduct();
        context.Products.Add(product);
        await context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product.ToProductViewModel());
    }

    // PUT: api/product/5
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateProduct(int id, ProductUpdateModel model)
    {
        if (id != model.Id)
            return BadRequest();

        var product = await context.Products.FindAsync(id);
        if (product == null)
            return NotFound(ErrorMessages.ProductNotFound);

        if (await context.Products.AnyAsync(p => p.Name == model.Name && p.Id != id))
            return BadRequest(ErrorMessages.ProductNameExists);

        model.ToProduct(product);
        await context.SaveChangesAsync();

        return NoContent();
    }

    // DELETE: api/product/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var product = await context.Products.FindAsync(id);

        if (product == null)
            return NotFound(ErrorMessages.ProductNotFound);

        context.Products.Remove(product);
        await context.SaveChangesAsync();

        return NoContent();
    }
}