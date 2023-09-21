using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductReview_WebAPI.Data;
using ProductReview_WebAPI.DTOs;
using ProductReview_WebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductReview_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ReviewsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Reviews
        [HttpGet]
        public IEnumerable<Review> Get()
        {
            var reviews = _context.Reviews.ToList();
               //.Select(r => new ReviewDTO
               // {
               //     Id = r.Id,
               //     Text = r.Text,
               //     Rating = r.Rating,
               // }).ToList();
            return reviews;
        }
        // GET api/Reviews/{Id}
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
                var review = _context.Reviews
                    .Find(id);
                return Ok(review);
        }

        // POST api/Reviews
        [HttpPost]
        public IActionResult Post([FromBody] Review review)
        {
            _context.Reviews.Add(review);
            _context.SaveChanges();
            return StatusCode(201, review);

        }

        // PUT api/Reviews/{Id}
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Review reviewToUpdate)
        {
            var review = _context.Reviews
               .Where(r => r.Id == id).Single();
            review.Text = reviewToUpdate.Text;
            review.Rating = reviewToUpdate.Rating;
            review.ProductId = reviewToUpdate.ProductId;
            _context.SaveChanges();
            return Ok(reviewToUpdate);
        }

        // DELETE api/Reviews/{Id}
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
