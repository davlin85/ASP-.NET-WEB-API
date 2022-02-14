using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _01_E_Commerce_System.Data;
using _01_E_Commerce_System.Models.Entities;
using _01_E_Commerce_System.Models.Models.Product;
using _01_E_Commerce_System.Models.Models.Category;
using _01_E_Commerce_System.Models.Input;

namespace _01_E_Commerce_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly SqlContext _context;

        public ProductController(SqlContext context)
        {
            _context = context;
        }

        // GET: api/Product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductGetPostModel>>> GetProducts()
        {
            var products = new List<ProductGetPostModel>();
            foreach (var product in await _context.Products.Include(x => x.Categories).ToListAsync())
                products.Add(new ProductGetPostModel(
                    product.Id,
                    product.ArticleNumber,
                    product.ProductName,
                    product.Description,
                    product.Price,
                    product.Quantity,
                    new CategoryModel(
                        product.Categories.CategoryName)));


            return products;
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductGetPostModel>> GetProduct(int id)
        {
            var productEntity = await _context.Products.Include(x => x.Categories).FirstOrDefaultAsync(x => x.Id == id);

            if(productEntity == null)
            {
                return NotFound();
            }

            return new ProductGetPostModel(
                productEntity.Id,
                productEntity.ArticleNumber,
                productEntity.ProductName,
                productEntity.Description,
                productEntity.Price,
                productEntity.Quantity, 
                    new CategoryModel(
                        productEntity.Categories.CategoryName));
        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ProductPutModel>>UpdateProduct(int id, ProductPutModel model)
        {
            if(id != model.Id)
            {
                return BadRequest();
            }

            var productEntity = await _context.Products.FindAsync(model.Id);
                productEntity.ArticleNumber = model.ArticleNumber;
                productEntity.ProductName = model.ProductName;
                productEntity.Description = model.Description;
                productEntity.Price = model.Price;
                productEntity.Quantity = model.Quantity;
                    new CategoryModel(
                        model.CategoryName);

            _context.Entry(productEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if(!ProductEntityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Product
        [HttpPost]
        public async Task<ActionResult<ProductGetPostModel>> PostProduct(ProductInput model)
        {
            if(await _context.Products.AnyAsync(x => x.ProductName == model.ProductName))
                return BadRequest();

            var productEntity = new ProductEntity(
                model.ArticleNumber,
                model.ProductName,
                model.Description,
                model.Price,
                model.Quantity);

            var categories = await _context.Categories.FirstOrDefaultAsync(x => x.CategoryName == model.Category);
            if (categories != null)
                productEntity.CategoriesId = categories.Id;
            else
                productEntity.Categories = new CategoryEntity(
                    model.Category);

            _context.Products.Add(productEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new {id = productEntity.Id},
                new ProductGetPostModel(
                    productEntity.Id,
                    productEntity.ArticleNumber,
                    productEntity.ProductName,
                    productEntity.Description,
                    productEntity.Price,
                    productEntity.Quantity,
                        new CategoryModel(
                            productEntity.Categories.CategoryName)));
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductEntity(int id)
        {
            var productEntity = await _context.Products.FindAsync(id);
            if (productEntity == null)
            {
                return NotFound();
            }

            _context.Products.Remove(productEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductEntityExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
