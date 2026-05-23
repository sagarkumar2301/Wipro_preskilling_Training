using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineBookStoreAPI.Data;
using OnlineBookStoreAPI.Models;

namespace OnlineBookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            return await _context.Books
                .Include(b => b.Author)
                .ToListAsync();
        }

        // GET: api/books/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await _context.Books
                .Include(b => b.Author)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (book == null)
            {
                return NotFound(new { message = "Book not found" });
            }

            return book;
        }

        // POST: api/books
        [HttpPost]
        public async Task<ActionResult<Book>> CreateBook(Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var authorExists = await _context.Authors.AnyAsync(a => a.Id == book.AuthorId);

            if (!authorExists)
            {
                return BadRequest(new { message = "Invalid Author ID" });
            }

            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
        }

        // PUT: api/books/1
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, Book updatedBook)
        {
            if (id != updatedBook.Id)
            {
                return BadRequest(new { message = "Book ID mismatch" });
            }

            var existingBook = await _context.Books.FindAsync(id);

            if (existingBook == null)
            {
                return NotFound(new { message = "Book not found" });
            }

            existingBook.Title = updatedBook.Title;
            existingBook.PublicationYear = updatedBook.PublicationYear;
            existingBook.AuthorId = updatedBook.AuthorId;

            await _context.SaveChangesAsync();

            return Ok(new { message = "Book updated successfully" });
        }

        // DELETE: api/books/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
            {
                return NotFound(new { message = "Book not found" });
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Book deleted successfully" });
        }
    }
}