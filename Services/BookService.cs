using System;
using System.Collections.Generic;
using System.Linq;
using BookProject.Data.Model;
using BookProject.Dto;

namespace BookProject.Services
{
	public class BookService
	{
		private readonly AppDbContext _context;

		public BookService(AppDbContext context)
		{
			_context = context;
		}

		public void AddBook(BookDTO bookDto)
		{
			var book = new Book()
			{
				Author = bookDto.Author,
				Description = bookDto.Description,
				Genre = bookDto.Genre,
				Title = bookDto.Title,
				CoverUrl = bookDto.CoverUrl,
				DateAdded = DateTime.Now,
				IsRead = bookDto.IsRead,
				Rate = bookDto.IsRead ? bookDto.Rate : null,
				DateRead = bookDto.IsRead ? bookDto.DateRead : null,
			};

			_context.Books.Add(book);
			_context.SaveChanges();
		}

		public List<Book> GetAllBooks() => _context.Books.ToList();

		public Book GetBookById(int bookId) => _context.Books.FirstOrDefault(b => b.Id == bookId);

		public Book UpdateBookById(int bookId, BookDTO bookDto)
		{
			var book = _context.Books.FirstOrDefault(b => b.Id == bookId);

			if (book != null)
			{
				book.Author = bookDto.Author;
				book.Description = bookDto.Description;
				book.Genre = bookDto.Genre;
				book.Title = bookDto.Title;
				book.CoverUrl = bookDto.CoverUrl;
				book.IsRead = bookDto.IsRead;
				book.Rate = bookDto.IsRead ? bookDto.Rate : null;
				book.DateRead = bookDto.IsRead ? bookDto.DateRead : null;

				_context.SaveChanges();
			}

			return book;
		}

		public void DeleteBookById(int bookId)
		{
			var book = _context.Books.FirstOrDefault(b => b.Id == bookId);

			if (book != null)
			{
				_context.Books.Remove(book);
				_context.SaveChanges();
			}
		}
	}
}