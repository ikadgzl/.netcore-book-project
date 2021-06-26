using System;
using System.Linq;
using BookProject.Data.Model;
using BookProject.Dto;

namespace BookProject.Services
{
	public class AuthorService
	{
		private readonly AppDbContext _context;

		public AuthorService(AppDbContext context)
		{
			_context = context;
		}

		public void AddAuthor(AuthorDto authorDto)
		{
			var author = new Author()
			{
				FullName = authorDto.FullName
			};

			_context.Authors.Add(author);
			_context.SaveChanges();
		}

		public AuthorWithBookDto GetAuthorWithBooks(int id)
		{
			var author = _context.Authors.Where(a => a.Id == id).Select(a => new AuthorWithBookDto()
			{
				FullName = a.FullName,
				Books = a.BookAuthors.Select(ba => ba.Book.Title).ToList()
			}).FirstOrDefault();

			return author;
		}
	}
}