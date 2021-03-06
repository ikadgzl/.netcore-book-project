using System;
using System.Collections.Generic;

namespace BookProject.Data.Model
{
	public class Book
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string Genre { get; set; }
		public bool IsRead { get; set; }
		public string CoverUrl { get; set; }
		public DateTime DateAdded { get; set; }
		public DateTime? DateRead { get; set; }
		public int? Rate { get; set; }

		public int PublisherId { get; set; }
		public Publisher Publisher { get; set; }

		public List<BookAuthor> BookAuthors { get; set; }
	}
}