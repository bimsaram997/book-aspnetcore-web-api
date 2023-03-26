using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Data.Services;
using my_books.Data.ViewModels;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public BooksService _booksService;
        public BooksController(BooksService booksService)
        {
            _booksService = booksService;
        }

        [HttpPost("addBook-with-authors")]
        public IActionResult AddBook([FromBody]BookVM book)
        {
            _booksService.AddBookWithAuthors(book);
            return Ok();
        }

        [HttpGet("listAdvance")]
        public IActionResult GetAllBooks()
        {
           var _books = _booksService.GetAllBooks();
            return Ok(_books);
        }

        [HttpGet("findById/{id}")]
        public IActionResult GetBookById(int bookId)
        {
            var _books = _booksService.GetBookById(bookId);
            return Ok(_books);
        }

        [HttpPut("updateBookById/{id}")]
        public IActionResult UpdateBookById(int bookid, [FromBody]BookVM book)
        {
            var _books = _booksService.UpdateBookById(bookid, book);
            return Ok(_books);
        }

        [HttpDelete("deleteByBookId/{id}")]
        public IActionResult DeleteBookById(int bookid)
        {
            _booksService.DeleteBookById(bookid);
            return Ok();
        }
    }
}
