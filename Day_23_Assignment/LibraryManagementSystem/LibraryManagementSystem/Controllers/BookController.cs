using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _repository;

        public BookController(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            var books = await _repository.GetBooksWithDetailsAsync();

            return View(books);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Book book)
        {
            if (ModelState.IsValid)
            {
                await _repository.AddAsync(book);

                await _repository.SaveAsync();

                return Json(new
                {
                    success = true,
                    message = "Book Added Successfully"
                });
            }

            return Json(new
            {
                success = false,
                message = "Invalid Data"
            });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);

            await _repository.SaveAsync();

            return Json(new
            {
                success = true
            });
        }
    }
}