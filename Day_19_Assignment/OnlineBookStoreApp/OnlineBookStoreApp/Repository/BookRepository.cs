using OnlineBookStoreApp.Models;

namespace OnlineBookStoreApp.Repository
{
    public class BookRepository : IBookRepository
    {
        private static List<Book> books = new List<Book>();

        public List<Book> GetAllBooks()
        {
            return books;
        }

        public Book GetBookById(int id)
        {
            return books.FirstOrDefault(x => x.Id == id);
        }

        public void AddBook(Book book)
        {
            books.Add(book);
        }
    }
}