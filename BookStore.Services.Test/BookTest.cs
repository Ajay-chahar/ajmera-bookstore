using BooksDemo.Services.BusinessLogic.Book;
using BooksDemo.Services.Contract.Dto;
using BookStore.Data.Models;
using BookStore.Services.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System.Web.Http.Results;
using Xunit.Sdk;
using BadRequestResult = System.Web.Http.Results.BadRequestResult;

namespace BookStore.Services.Test
{
    [TestClass]
    public class BookTest
    {
        private MockRepository _mockRepository;
        private readonly ILogger<BooksController> _logger;
        private readonly IBookHander _bookHander;

        public BookTest(ILogger<BooksController> logger, IBookHander bookHander)
        {
            _logger = logger;
            _bookHander = bookHander;
        }


        [TestMethod]
        public void getbookbyid_success()
        {
            string bookId = "3297f0f2-35d3-4231-919d-1cfcf4035975";

            BookDto book = new BookDto();
            List<BookDto> bookList = new List<BookDto>();
            book.Id = Guid.Parse(bookId);
            book.Name = "Nothing can be achieved without your efforts";
            book.AuthorName = "Ajay Chahar";
            bookList.Add(book);
            var controller = new BooksController(_bookHander, _logger);

            //mock the getBookbyId.
            var mock = _mockRepository.Create<IBookHander>();
            mock.Setup(x=> x.GetBookById(bookId)).Returns(bookList);

            var response = controller.Get(bookId);

            Assert.IsInstanceOfType(response, typeof(OkNegotiatedContentResult<string>));

        }

        [TestMethod]
        public void getbookbyid_fail()
        {
            string bookId = "12345";
            var controller = new BooksController(_bookHander, _logger);

            var response = controller.Get(bookId);

            Assert.IsInstanceOfType(response, typeof(BadRequestResult));

        }
    }
}