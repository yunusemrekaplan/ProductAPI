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
public class BrandController(ApplicationDbContext context) : ControllerBase
{
    // GET: api/brand
    [HttpGet]
    public async Task<ActionResult<IEnumerable<BrandViewModel>>> GetBrands()
    {
        return await context.Brands
            .AsNoTracking()
            .Include(b => b.ProductModels)
            .Select(b => b.ToBrandViewModel())
            .ToListAsync();
    }

    // GET: api/brand/5
    [HttpGet("{id:int}")]
    public async Task<ActionResult<BrandViewModel>> GetBrand(int id)
    {
        var brand = await context.Brands
            .AsNoTracking()
            .Include(b => b.ProductModels)
            .FirstOrDefaultAsync(b => b.Id == id);

        if (brand == null)
            return NotFound(ErrorMessages.BrandNotFound);

        return brand.ToBrandViewModel();
    }

    // POST: api/brand
    [HttpPost]
    public async Task<ActionResult<BrandViewModel>> CreateBrand(BrandCreateModel model)
    {
        if (await context.Brands.AnyAsync(b => b.Name == model.Name))
            return BadRequest(ErrorMessages.BrandNameExists);

        var brand = model.ToBrand();
        context.Brands.Add(brand);
        await context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetBrand), new { id = brand.Id }, brand.ToBrandViewModel());
    }

    // PUT: api/brand/5
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateBrand(int id, BrandUpdateModel model)
    {
        if (id != model.Id)
            return BadRequest();

        var brand = await context.Brands.FindAsync(id);
        if (brand == null)
            return NotFound(ErrorMessages.BrandNotFound);

        if (await context.Brands.AnyAsync(b => b.Name == model.Name && b.Id != id))
            return BadRequest(ErrorMessages.BrandNameExists);

        model.ToBrand(brand);
        await context.SaveChangesAsync();

        return NoContent();
    }

    // DELETE: api/brand/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteBrand(int id)
    {
        var brand = await context.Brands
            .Include(b => b.ProductModels)
            .FirstOrDefaultAsync(b => b.Id == id);

        if (brand == null)
            return NotFound(ErrorMessages.BrandNotFound);

        if (brand.ProductModels?.Any() == true)
            return BadRequest(ErrorMessages.CannotDeleteBrandWithProductModels);

        context.Brands.Remove(brand);
        await context.SaveChangesAsync();

        return NoContent();
    }
}