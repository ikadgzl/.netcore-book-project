using System;
using System.Linq;
using BookProject.Data.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BookProject.Data
{
	public class AppDbInitializer
	{
		public static void Seed(IApplicationBuilder builder)
		{
			using (var serviceScope = builder.ApplicationServices.CreateScope())
			{
				var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

				if (!context.Books.Any())
				{
					context.Books.AddRange(
						new Book()
						{
							Author = "Ilker",
							Description = "Ilker's book",
							Genre = "Horror",
							Rate = 6,
							Title = "Ilker's book title",
							CoverUrl = "something.url/bookurl",
							DateAdded = DateTime.Now,
							DateRead = DateTime.Now.AddDays(-10),
							IsRead = false
						},
						new Book()
						{
							Author = "Zehra",
							Description = "Zehra's book",
							Genre = "Fiction",
							Rate = 5,
							Title = "Zehra's book title",
							CoverUrl = "something.url/bookurl",
							DateAdded = DateTime.Now,
							DateRead = DateTime.Now.AddDays(-12),
							IsRead = true
						}
					);

					context.SaveChanges();
				}
			}
		}
	}
}