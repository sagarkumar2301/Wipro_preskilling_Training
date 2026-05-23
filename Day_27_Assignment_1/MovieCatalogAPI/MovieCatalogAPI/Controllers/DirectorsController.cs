using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieCatalogAPI.Data;
using MovieCatalogAPI.Models;

namespace MovieCatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DirectorsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/directors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Director>>> GetDirectors()
        {
            return await _context.Directors.ToListAsync();
        }

        // POST: api/directors
        [HttpPost]
        public async Task<ActionResult<Director>> CreateDirector(Director director)
        {
            _context.Directors.Add(director);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDirectors),
                new { id = director.Id }, director);
        }

        // GET: api/directors/1/movies
        [HttpGet("{directorId}/movies")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMoviesByDirector(int directorId)
        {
            var director = await _context.Directors.FindAsync(directorId);

            if (director == null)
            {
                return NotFound(new { message = "Director not found" });
            }

            var movies = await _context.Movies
                .Where(m => m.DirectorId == directorId)
                .ToListAsync();

            return movies;
        }
    }
}