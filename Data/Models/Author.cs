using System.Collections.Generic;

namespace BookProject.Data.Model
{
	public class Author
	{
		public int Id { get; set; }
		public string FullName { get; set; }

		public List<BookAuthor> BookAuthors { get; set; }
	}
}