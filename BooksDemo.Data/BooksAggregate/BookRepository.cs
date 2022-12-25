using BookStore.Data.Models;

namespace BooksDemo.Data.BooksAggregate
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext _bookStoreContext;
        public BookRepository(BookStoreContext bookStoreContext)
        {
            _bookStoreContext = bookStoreContext;
        }

        public List<Book> GetBooks()
        {
            return _bookStoreContext.Books.ToList();
        }

        public List<Book> GetBookById(string id)
        {
           return   _bookStoreContext.Books.Where(x => x.Id == Guid.Parse(id)).ToList();          
        }

        public Book AddBook(Book book)
        {
            _bookStoreContext.Books.Add(book);
            _bookStoreContext.SaveChanges();
            return book;
        }
    }
}
