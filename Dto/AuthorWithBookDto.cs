using System.Collections.Generic;

namespace BookProject.Dto
{
	public class AuthorWithBookDto
	{
		public string FullName { get; set; }
		public List<string> Books { get; set; }
	}
}