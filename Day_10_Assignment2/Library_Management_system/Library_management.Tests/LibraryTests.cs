using Library_management_system;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Library_management.Tests
{
    [TestClass]
    public class LibraryTests
    {
        private Library _library;

        [TestInitialize]
        public void Setup()
        {
            _library = new Library();
        }

        // ✅ 1. Add Book Test
        [TestMethod]
        public void AddBook_ShouldAddBookToLibrary()
        {
            var book = new Book("C#", "John", "123");

            _library.AddBook(book);

            Assert.AreEqual(1, _library.Books.Count);
        }

        // ✅ 2. Register Borrower Test
        [TestMethod]
        public void RegisterBorrower_ShouldAddBorrower()
        {
            var borrower = new Borrower("Sagar", "CARD1");

            _library.RegisterBorrower(borrower);

            Assert.AreEqual(1, _library.Borrowers.Count);
        }

        // ✅ 3. Borrow Book Test
        [TestMethod]
        public void BorrowBook_ShouldMarkBookAsBorrowed()
        {
            var book = new Book("C#", "John", "123");
            var borrower = new Borrower("Sagar", "CARD1");

            _library.AddBook(book);
            _library.RegisterBorrower(borrower);

            _library.BorrowBook("123", "CARD1");

            Assert.IsTrue(book.IsBorrowed);
            Assert.AreEqual(1, borrower.BorrowedBooks.Count);
        }

        // ✅ 4. Return Book Test
        [TestMethod]
        public void ReturnBook_ShouldMakeBookAvailable()
        {
            var book = new Book("C#", "John", "123");
            var borrower = new Borrower("Sagar", "CARD1");

            _library.AddBook(book);
            _library.RegisterBorrower(borrower);
            _library.BorrowBook("123", "CARD1");

            _library.ReturnBook("123", "CARD1");

            Assert.IsFalse(book.IsBorrowed);
            Assert.AreEqual(0, borrower.BorrowedBooks.Count);
        }

        // ✅ 5. View Books Test
        [TestMethod]
        public void ViewBooks_ShouldReturnAllBooks()
        {
            _library.AddBook(new Book("Book1", "A", "1"));

            var books = _library.ViewBooks();

            Assert.AreEqual(1, books.Count);
        }

        // ✅ 6. View Borrowers Test
        [TestMethod]
        public void ViewBorrowers_ShouldReturnAllBorrowers()
        {
            _library.RegisterBorrower(new Borrower("Sagar", "CARD1"));

            var borrowers = _library.ViewBorrowers();

            Assert.AreEqual(1, borrowers.Count);
        }
    }
}
