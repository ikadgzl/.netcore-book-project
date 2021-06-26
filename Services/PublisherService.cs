using System.Linq;
using BookProject.Data.Model;
using BookProject.Dto;

namespace BookProject.Services
{
	public class PublisherService
	{
		private readonly AppDbContext _context;

		public PublisherService(AppDbContext context)
		{
			_context = context;
		}

		public void AddPublisher(PublisherDto publisherDto)
		{
			var publisher = new Publisher()
			{
				Name = publisherDto.Name
			};

			_context.Publishers.Add(publisher);
			_context.SaveChanges();
		}

		public PublisherWithBookAndAuthorDto GetPublisherById(int publisherId)
		{
			var publisher = _context.Publishers.Where(p => p.Id == publisherId).Select(p =>
				new PublisherWithBookAndAuthorDto()
				{
					Name = p.Name,
					BookAuthors = p.Books.Select(b => new BookAuthorDto()
					{
						BookTitle = b.Title,
						BookAuthors = b.BookAuthors.Select(ba => ba.Author.FullName).ToList()
					}).ToList()
				}).FirstOrDefault();

			return publisher;
		}

		public void DeletePublisherById(int id)
		{
			var publisher = _context.Publishers.FirstOrDefault(n => n.Id == id);

			if (publisher != null)
			{
				_context.Publishers.Remove(publisher);
				_context.SaveChanges();
			}
		}
	}
}