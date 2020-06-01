using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rozproszone.Models;

namespace Rozproszone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookReviewsController : ControllerBase
    {
        private BookReviewContext _context;

        public BookReviewsController(BookReviewContext reviewContext)
        {
            _context = reviewContext;
        }
        [HttpGet]
        public IEnumerable<BookReview> GetBookReviews()
        {
            return _context.BookReviews.ToList();
        }

        [HttpGet("{title}")]
        public IEnumerable<BookReview> GetBookReview([FromRoute] string title)
        {
            return _context.BookReviews.Where(b => b.Title == title);
        }
        [HttpPost]
        public ActionResult<BookReview> PostBookReview(BookReview bookReview)
        {
            _context.BookReviews.Add(bookReview);
            _context.SaveChanges();

            return NoContent();
        }
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult PutBook(BookReview bookReview, int id)
        {
            if (id != bookReview.Id)
            {
                return BadRequest();
            }
            _context.BookReviews.Update(bookReview);
            _context.SaveChanges();

            return NoContent();
        }
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(BookReview bookReview, int id)
        {
            var Book = _context.BookReviews.Find(id);
            if (Book == null)
            {
                return NotFound();
            }
            _context.BookReviews.Remove(bookReview);
            _context.SaveChanges();

            return NoContent();
        }
    }
}