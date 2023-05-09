using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.ActionResults;
using my_books.Data.Models;
using my_books.Data.Services;
using my_books.Data.ViewModels;
using my_books.Exceptions;

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

            try
            {
                var newPublisher = _publishersService.AddPublisher(publisher);
                return Created(nameof(AddPublisher), newPublisher);
            }
            catch (PublisherNameException ex)
            {
                return BadRequest($"{ex.Message}, Publisher name:{ex.PublisherName}");
            }
            catch (Exception ex)
            {

              return BadRequest(ex);
            }
         
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
         
            try
            {
   
                _publishersService.DeletebyPubliserId(publisherId);
                return Ok();
            }

            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
          

        }

        [HttpGet("findByPubliserById/{id}")]
        public IActionResult GetPublisherId(int publisherId)
        {
            //throw new Exception("This is an excpetion that will be handled by middleware");
            var _response = _publishersService.GetPublisherById(publisherId);
            if (_response != null)
            {
                return Ok(_response);
            }
            else
            {
                return NotFound();
            }

        }

        //spefic type

        [HttpGet("findByPubliserSpecificById/{id}")]
        public Publisher GetPublisherSpecificId(int publisherId)
        {
            //throw new Exception("This is an excpetion that will be handled by middleware");
            var _response = _publishersService.GetPublisherById(publisherId);
            if (_response != null)
            {
                return _response;
            }
            else
            {
                return null; ;
            }

        }

        //custom type

        [HttpGet("findByPubliserCustomById/{id}")]
        public CustomActionResult GetPublisherCustomId(int publisherId)
        {
            //throw new Exception("This is an excpetion that will be handled by middleware");
            var _response = _publishersService.GetPublisherById(publisherId);
            if (_response != null)
            {
                var _repsonseObj = new CustomActionResultVM()
                {
                    Publisher = _response
                };
                return new CustomActionResult(_repsonseObj);
            }
            else
            {
                var _repsonseObj = new CustomActionResultVM()
                {
                    Exception = new Exception("this is comming from app")
                };
                return new CustomActionResult(_repsonseObj);
            }

        }
    }
}
