using System;
using System.Collections.Generic;

namespace BookProject.Dto
{
	public class BookDto
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public string Genre { get; set; }
		public bool IsRead { get; set; }
		public string CoverUrl { get; set; }
		public DateTime? DateRead { get; set; }
		public int? Rate { get; set; }

		public int PublisherId { get; set; }
		public List<int> AuthorIds { get; set; }		
	}
}