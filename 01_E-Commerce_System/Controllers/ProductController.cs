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
            foreach (var product in await _context.Products
                .Include(x => x.Categories)
                .ToListAsync())

                products.Add(new ProductGetPostModel(
                    product.Id,
                    product.ProductName,
                    product.Description,
                    product.Price,
                    product.Quantity,
                        new CategoryModel(
                            product.Categories.Category)));

            return products;
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductGetPostModel>> GetProduct(int id)
        {
            var productEntity = await _context.Products
                .Include(x => x.Categories)
                .FirstOrDefaultAsync(x => x.Id == id);

            if(productEntity == null)
            {
                return NotFound("Product Id doesn't exist! Try again!");
            }

            return new ProductGetPostModel(
                productEntity.Id,
                productEntity.ProductName,
                productEntity.Description,
                productEntity.Price,
                productEntity.Quantity, 
                    new CategoryModel(
                        productEntity.Categories.Category));
        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ProductPutModel>>UpdateProduct(int id, ProductPutModel model)
        {
            if(id != model.Id)
            {
                return BadRequest("Order Id doesn't exist! Try again!");
            }

            var productEntity = await _context.Products
                .FindAsync(model.Id);

                productEntity.ProductName = model.ProductName;
                productEntity.Description = model.Description;
                productEntity.Price = model.Price;
                productEntity.Quantity = model.Quantity;

            var categories = await _context.Categories
                .FirstOrDefaultAsync(x => x.Category == model.Category);

            if(categories != null)
                productEntity.CategoriesId = categories.Id;
            else
                productEntity.Categories = new CategoryEntity(
                    model.Category);


            _context.Entry(productEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if(!ProductEntityExists(id))
                {
                    return NotFound("Something went wrong! Try again!");
                }
                else
                {
                    throw;
                }
            }

            return Ok("Your Product is updated!");
        }

        // POST: api/Product
        [HttpPost]
        public async Task<ActionResult<ProductGetPostModel>> PostProduct(ProductInput model)
        {
            if(await _context.Products
                .AnyAsync(x => x.ProductName == model.ProductName))

                return BadRequest("A Product with the same Product Name already exist! Try again!");

            var productEntity = new ProductEntity(
                model.ProductName,
                model.Description,
                model.Price,
                model.Quantity);

            var categories = await _context.Categories.
                FirstOrDefaultAsync(x => x.Category == model.Category);

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
                    productEntity.ProductName,
                    productEntity.Description,
                    productEntity.Price,
                    productEntity.Quantity,
                        new CategoryModel(
                            productEntity.Categories.Category)));
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductEntity(int id)
        {
            var productEntity = await _context.Products
                .FindAsync(id);

            if (productEntity == null)
            {
                return NotFound("Product Id doesn't exist! Try again!");
            }

            _context.Products
                .Remove(productEntity);

            await _context.SaveChangesAsync();

            return Ok("Your Product is deleted!");
        }

        private bool ProductEntityExists(int id)
        {
            return _context.Products
                .Any(e => e.Id == id);
        }
    }
}
