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

		public void AddBook(BookDto bookDto)
		{
			var book = new Book()
			{
				Description = bookDto.Description,
				Genre = bookDto.Genre,
				Title = bookDto.Title,
				CoverUrl = bookDto.CoverUrl,
				DateAdded = DateTime.Now,
				IsRead = bookDto.IsRead,
				Rate = bookDto.IsRead ? bookDto.Rate : null,
				DateRead = bookDto.IsRead ? bookDto.DateRead : null,
				PublisherId = bookDto.PublisherId,
			};

			_context.Books.Add(book);
			_context.SaveChanges();

			foreach (var authorId in bookDto.AuthorIds)
			{
				var bookAuthor = new BookAuthor()
				{
					BookId = book.Id,
					AuthorId = authorId
				};

				_context.BookAuthors.Add(bookAuthor);
				_context.SaveChanges();
			}
		}

		public List<Book> GetAllBooks() => _context.Books.ToList();

		public BookWithAuthorDto GetBookById(int bookId)
		{
			var bookWithAuthor = _context.Books.Where(n => n.Id == bookId).Select(book => new BookWithAuthorDto()
			{
				Description = book.Description,
				Genre = book.Genre,
				Title = book.Title,
				CoverUrl = book.CoverUrl,
				IsRead = book.IsRead,
				Rate = book.IsRead ? book.Rate : null,
				DateRead = book.IsRead ? book.DateRead : null,
				PublisherName = book.Publisher.Name,
				AuthorNames = book.BookAuthors.Select(n => n.Author.FullName).ToList()
			}).FirstOrDefault();

			return bookWithAuthor;
		}

		public Book UpdateBookById(int bookId, BookDto bookDto)
		{
			var book = _context.Books.FirstOrDefault(b => b.Id == bookId);

			if (book != null)
			{
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