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
        public IEnumerable<Product> Get()
        {
            var products = _context.Products.ToList();

            return products;
        }

        // GET api/Products/{Id}
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/Products
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/Products/{Id}
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/Products/{Id}
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
