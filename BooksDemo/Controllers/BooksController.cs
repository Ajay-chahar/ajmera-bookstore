using BooksDemo.Services.BusinessLogic.Book;
using BooksDemo.Services.Contract.Dto;
using BookStore.Data.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStore.Services.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ILogger<BooksController> _logger;
        private readonly IBookHander _bookHander;
        public BooksController(IBookHander bookHander, ILogger<BooksController> logger) 
        {
            _bookHander = bookHander;
            _logger = logger;
        }

        // GET: api/<BooksController> //
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var bookInfo = _bookHander.GetBooks();

                if (bookInfo == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(bookInfo);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message.ToString());
                return BadRequest();
            }
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {          
            try
            {
                var bookInfo = _bookHander.GetBookById(id);

                if (bookInfo == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(bookInfo);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message.ToString());
                return BadRequest();
            }
        }

        // POST api/<BooksController>
        [HttpPost]
        public IActionResult Post([FromBody] BookDto book)
        {
            try
            {
                var bookInfo = _bookHander.AddBook(book);

                if (bookInfo == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(bookInfo);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message.ToString());
                return BadRequest();
            }
        }

        /*
        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */
    }
}
