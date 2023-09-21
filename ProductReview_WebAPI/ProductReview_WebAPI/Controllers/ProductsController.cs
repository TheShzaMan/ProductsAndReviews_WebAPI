using Microsoft.AspNetCore.Mvc;
using ProductReview_WebAPI.Data;
using ProductReview_WebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductReview_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public IEnumerable<Product> Get([FromQuery] double? maxPrice)
        {
            var products = _context.Products.ToList();
            if (maxPrice != null) 
            {
                products = products.Where(p => p.Price < maxPrice).ToList();
            }
            return products;
        }

        // GET api/Products/{Id}
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public IActionResult PostProduct([FromBody] Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return StatusCode(201, product);

        }

        // PUT api/Products/{Id}
        [HttpPut("{id}")]
        public IActionResult PutProduct(int id, [FromBody] Product ProductToUpdate)
        {
            var product = _context.Products
               .Where(p => p.Id == id).Single();
            product.Name = ProductToUpdate.Name;
            product.Price = ProductToUpdate.Price;
            _context.SaveChanges();
            return Ok(ProductToUpdate);
        }

        // DELETE api/Products/{Id}
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var productToDelete = _context.Products
                .Find(id);
            _context.Products.Remove(productToDelete);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
