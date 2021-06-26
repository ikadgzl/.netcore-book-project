using BookProject.Dto;
using BookProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookProject.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthorController : ControllerBase
	{
		private readonly AuthorService _authorService;

		public AuthorController(AuthorService authorService)
		{
			_authorService = authorService;
		}

		[HttpPost("add-author")]
		public IActionResult AddAuthor([FromBody] AuthorDto authorDto)
		{
			_authorService.AddAuthor(authorDto);

			return Ok();
		}

		[HttpGet("get-author/{id}")]
		public IActionResult GetAuthorById(int id)
		{
			return Ok(_authorService.GetAuthorWithBooks(id));
		}
	}
}