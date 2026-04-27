using System.Collections.Generic;
using System.Linq;

namespace Library_management_system
{
    public class Book
    {
        public string Title { get; }
        public string Author { get; }
        public string Isbn { get; }
        public bool IsBorrowed { get; set; }

        public Book(string title, string author, string isbn)
        {
            Title = title;
            Author = author;
            Isbn = isbn;
            IsBorrowed = false;
        }
    }

    public class Borrower
    {
        public string Name { get; }
        public string CardId { get; }
        public List<Book> BorrowedBooks { get; }

        public Borrower(string name, string cardId)
        {
            Name = name;
            CardId = cardId;
            BorrowedBooks = new List<Book>();
        }
    }

    public class Library
    {
        public List<Book> Books { get; }
        public List<Borrower> Borrowers { get; }

        public Library()
        {
            Books = new List<Book>();
            Borrowers = new List<Borrower>();
        }

        public void AddBook(Book book)
        {
            if (book != null) Books.Add(book);
        }

        public void RegisterBorrower(Borrower borrower)
        {
            if (borrower != null) Borrowers.Add(borrower);
        }

        public void BorrowBook(string isbn, string cardId)
        {
            var book = Books.FirstOrDefault(b => b.Isbn == isbn && !b.IsBorrowed);
            var borrower = Borrowers.FirstOrDefault(b => b.CardId == cardId);
            if (book != null && borrower != null)
            {
                book.IsBorrowed = true;
                borrower.BorrowedBooks.Add(book);
            }
        }

        public void ReturnBook(string isbn, string cardId)
        {
            var book = Books.FirstOrDefault(b => b.Isbn == isbn && b.IsBorrowed);
            var borrower = Borrowers.FirstOrDefault(b => b.CardId == cardId);
            if (book != null && borrower != null && borrower.BorrowedBooks.Contains(book))
            {
                book.IsBorrowed = false;
                borrower.BorrowedBooks.Remove(book);
            }
        }

        public List<Book> ViewBooks() => new List<Book>(Books);
        public List<Borrower> ViewBorrowers() => new List<Borrower>(Borrowers);
    }
}
