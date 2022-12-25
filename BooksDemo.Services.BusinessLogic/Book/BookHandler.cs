using AutoMapper;
using BooksDemo.Data.BooksAggregate;
using BooksDemo.Services.Contract.Dto;
using BookStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksDemo.Services.BusinessLogic.Book
{
    public interface IBookHander
    {
        List<BookDto> GetBooks();
        List<BookDto> GetBookById(string id);
        BookDto AddBook(BookDto book);


    }
    public class BookHandler : IBookHander
    {
        private IMapper _mapper { get; }
        private readonly IBookRepository _bookRepository;
        public BookHandler(IBookRepository bookRepository, IMapper mapper) 
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public List<BookDto> GetBooks()
        {
            var bookDetails = _bookRepository.GetBooks();

            var result = _mapper.Map<List<BookDto>>(bookDetails);

            return result;
        }

        public List<BookDto> GetBookById(string id)
        {
            var bookDetails = _bookRepository.GetBookById(id);

            var result = _mapper.Map<List<BookDto>>(bookDetails);

            return result;
        }

        public BookDto AddBook(BookDto book)
        {
            book.Id = Guid.NewGuid();

            var bookMapper = _mapper.Map<BookStore.Data.Models.Book>(book);
            var bookData = _bookRepository.AddBook(bookMapper);

            var result = _mapper.Map<BookDto>(bookData);
            return result;
        }
    }
}
