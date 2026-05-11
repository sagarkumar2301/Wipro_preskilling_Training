using OnlineBookStoreApp.Models;

namespace OnlineBookStoreApp.Repository
{
    public interface IBookRepository
    {
        List<Book> GetAllBooks();

        Book GetBookById(int id);

        void AddBook(Book book);
    }
}