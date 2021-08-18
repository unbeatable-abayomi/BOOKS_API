using BooksProAPI.Data.Services;
using BooksProAPI.Data.ViewModels;
using BooksProAPI.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksProAPI.Controllers
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


        [HttpPost("add-publiher")]

        public IActionResult AddPublisher([FromBody] PublisherVM publisherVM)
        {
            try
            {
                var newPublisher = _publishersService.AddPublisher(publisherVM);
                return Created(nameof(AddPublisher), newPublisher);
            }
            catch (PublisherNameException ex)
            {
                return BadRequest($"{ex.Message}, Publisher Name : {ex.PublisherName}");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
          
        }

        [HttpGet("get-publisher-by-id/{id}")]

        public IActionResult GetPublisherById(int id)
        {
            var _response = _publishersService.GetPublisherById(id);

            if (_response != null)
            {
                return Ok(_response);
            }
            else
            {
                return NotFound();
            }
            
        }

        [HttpGet("get-publisher-books-with-authors/{id}")]

        public IActionResult GetPublisherData(int id)
        {
            var _response = _publishersService.GetPublishersData(id);
            return Ok(_response);
        }

        [HttpDelete("delete-publisher-id/{id}")]

        public IActionResult DeletePublisherById(int id)
        {

            try
            {
                //int x1 = 1;
                //int x2 = 0;
                //int result = x1 / x2;

                _publishersService.DeletePublisherById(id);

                return Ok();
            }
            //catch (ArithmeticException ex)
            //{

            //    return BadRequest(ex.Message);
            //}
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            //finally { string stopHere = ""; }
        }
    }
}
