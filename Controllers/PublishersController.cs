using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Data.Services;
using my_books.Data.ViewModels;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private PublishersService _publishersService;
        public PublishersController(PublishersService publishersService)
        {
            _publishersService = publishersService;
        }
        [HttpPost("add-Publisher")]
        public IActionResult AddPublisher([FromBody] PublisherVM publisher)
        {
            _publishersService.AddPublisher(publisher);
            return Ok();
        }


        [HttpGet("findByPubliser-books-authors/{id}")]
        public IActionResult GetPublisherData(int publisherId)
        {
            var _response = _publishersService.GetPublisherData(publisherId);
            return Ok(_response);
        }

        [HttpDelete("delete-publiser-by-id/{id}")]
        public IActionResult DeletebyPubliserId(int publisherId)
        {
          _publishersService.DeletebyPubliserId(publisherId);
            return Ok();
           
        }
    }
}
