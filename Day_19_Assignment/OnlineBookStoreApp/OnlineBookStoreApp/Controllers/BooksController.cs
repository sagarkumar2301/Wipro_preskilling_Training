
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using OnlineBookStoreApp.Models;
using OnlineBookStoreApp.Repository;

namespace OnlineBookStoreApp.Controllers
{
    
    public class BooksController : Controller
    {
        private readonly IBookRepository _repository;

        public BooksController(IBookRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var books = _repository.GetAllBooks();
            return View(books);
        }

        [Route("Book/Details/{id:int}")]
        public IActionResult Details(int id)
        {
            var book = _repository.GetBookById(id);
            return View(book);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _repository.AddBook(book);

                HttpContext.Session.SetInt32("CartCount", 1);

                return RedirectToAction("Index");
            }

            return View(book);
        }
    }
}