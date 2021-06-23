using System;

namespace BookProject.Dto
{
	public class BookDTO
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public string Author { get; set; }
		public string Genre { get; set; }
		public bool IsRead { get; set; }
		public string CoverUrl { get; set; }
		public DateTime DateAdded { get; set; }
		public DateTime? DateRead { get; set; }
		public int? Rate { get; set; }
	}
}