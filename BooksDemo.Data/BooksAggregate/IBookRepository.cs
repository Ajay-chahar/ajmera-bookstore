using BookStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksDemo.Data.BooksAggregate
{
    public interface IBookRepository
    {
        List<Book> GetBooks();
        List<Book> GetBookById(string id);
        Book AddBook(Book book);
    }
}
