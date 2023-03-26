using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Data.Services;
using my_books.Data.ViewModels;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private AuthorService _authorService;
        public AuthorsController(AuthorService authorService)
        {
            _authorService= authorService;
        }
        [HttpPost("add-Author")]
        public IActionResult AddAuthor([FromBody] AuthorVM author)
        {
            _authorService.AddAuthor(author);
            return Ok();
        }

        [HttpGet("get-author-with-books-by-id/{id}")]
        public IActionResult GetAuthorById(int authorId)
        {
            var _author = _authorService.GetAuthorWithBooks(authorId);
            return Ok(_author);
        }
    }
}
