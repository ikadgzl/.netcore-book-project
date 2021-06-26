using BookProject.Dto;
using BookProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookProject.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PublisherController : ControllerBase
	{
		private readonly PublisherService _publisherService;

		public PublisherController(PublisherService publisherService)
		{
			_publisherService = publisherService;
		}

		[HttpPost("add-publisher")]
		public IActionResult AddPublisher([FromBody] PublisherDto publisherDto)
		{
			_publisherService.AddPublisher(publisherDto);

			return Ok();
		}
		
		[HttpGet("get-publisher/{id}")]
		public IActionResult GetPublisherById(int id)
		{
			return Ok(_publisherService.GetPublisherById(id));
		}
		
		
		[HttpDelete("delete-publisher/{id}")]
		public IActionResult DeletePublisherById(int id)
		{
			_publisherService.DeletePublisherById(id);
			
			return Ok();
		}
	}
}