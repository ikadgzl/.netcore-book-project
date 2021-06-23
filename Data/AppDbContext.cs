using Microsoft.EntityFrameworkCore;

namespace BookProject.Data.Model
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}

		public DbSet<Book> Books { get; set; }
	}
}