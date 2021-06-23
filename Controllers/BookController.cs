using BookProject.Dto;
using BookProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookProject.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BookController : ControllerBase
	{
		private readonly BookService _bookService;

		public BookController(BookService service)
		{
			_bookService = service;
		}

		[HttpPost("add-book")]
		public IActionResult AddBook([FromBody] BookDTO bookDto)
		{
			_bookService.AddBook(bookDto);

			return Ok();
		}

		[HttpGet("get-all-books")]
		public IActionResult GetAllBooks()
		{
			var allBooks = _bookService.GetAllBooks();

			return Ok(allBooks);
		}

		[HttpGet("get-book/{id}")]
		public IActionResult GetBookById(int id)
		{
			var book = _bookService.GetBookById(id);

			return Ok(book);
		}

		[HttpPut("update-book/{id}")]
		public IActionResult UpdateBookById(int id, [FromBody] BookDTO bookDto)
		{
			var book = _bookService.UpdateBookById(id, bookDto);

			return Ok(book);
		}

		[HttpDelete("delete-book/{id}")]
		public IActionResult DeleteBookById(int id)
		{
			_bookService.DeleteBookById(id);

			return Ok();
		}
	}
}