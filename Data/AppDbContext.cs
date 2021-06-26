using Microsoft.EntityFrameworkCore;

namespace BookProject.Data.Model
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<BookAuthor>()
				.HasOne(b => b.Book)
				.WithMany(ba => ba.BookAuthors)
				.HasForeignKey(ba => ba.BookId);

			modelBuilder.Entity<BookAuthor>()
				.HasOne(a => a.Author)
				.WithMany(ba => ba.BookAuthors)
				.HasForeignKey(ba => ba.AuthorId);
		}

		public DbSet<Book> Books { get; set; }
		public DbSet<Author> Authors { get; set; }
		public DbSet<Publisher> Publishers { get; set; }
		public DbSet<BookAuthor> BookAuthors { get; set; }
	}
}