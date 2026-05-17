using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Controllers
{
    public class GenreController : Controller
    {
        private readonly LibraryDbContext _context;

        public GenreController(LibraryDbContext context)
        {
            _context = context;
        }

        // READ
        public async Task<IActionResult> Index()
        {
            var genres = await _context.Genres.ToListAsync();

            return View(genres);
        }

        // CREATE GET
        public IActionResult Create()
        {
            return View();
        }

        // CREATE POST
        [HttpPost]
public async Task<IActionResult> Create(Genre genre)
{
    if (ModelState.IsValid)
    {
        _context.Genres.Add(genre);

        await _context.SaveChangesAsync();

        return RedirectToAction("Index");
    }

    return View(genre);
}

        // DELETE
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var genre = await _context.Genres.FindAsync(id);

                if (genre != null)
                {
                    _context.Genres.Remove(genre);

                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}