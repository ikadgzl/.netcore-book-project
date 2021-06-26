using System.Collections.Generic;

namespace BookProject.Dto
{
	public class PublisherWithBookAndAuthorDto
	{
		public string Name { get; set; }
		public List<BookAuthorDto> BookAuthors { get; set; }
	}
}