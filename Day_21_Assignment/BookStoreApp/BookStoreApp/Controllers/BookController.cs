using Microsoft.AspNetCore.Mvc;
using BookStoreApp.DAL;
using BookStoreApp.Models;

namespace BookStoreApp.Controllers
{
    public class BookController : Controller
    {
        private readonly BookDAL dal;

        public BookController(IConfiguration configuration)
        {
            dal = new BookDAL(configuration);
        }

        public IActionResult Index()
        {
            var books = dal.GetAllBooks();

            return View(books);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            dal.AddBook(book);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            dal.DeleteBook(id);

            return RedirectToAction("Index");
        }
    }
}