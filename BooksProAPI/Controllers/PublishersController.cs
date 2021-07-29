using BooksProAPI.Data.Services;
using BooksProAPI.Data.ViewModels;
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
            _publishersService.AddPubliher(publisherVM);
            return Ok();
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
            _publishersService.DeletePublisherById(id);

            return Ok();
        }
    }
}
