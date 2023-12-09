using LibApp.Data;
using Microsoft.EntityFrameworkCore;

namespace LibApp.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = 
                new ApplicationDbContext(
                    serviceProvider.GetRequiredService<
                        DbContextOptions<ApplicationDbContext>>()))
            {
                if (!context.MembershipTypes.Any())
                {
                    context.MembershipTypes.AddRange(
                        new MembershipType { Name = "Pay as you go", SignUpFee = 0, DurationInMonths = 0, DiscountRate = 0 },
                        new MembershipType { Name = "Monthly", SignUpFee = 30, DurationInMonths = 3, DiscountRate = 5 },
                        new MembershipType { Name = "Quaterly", SignUpFee = 90, DurationInMonths = 6, DiscountRate = 10 },
                        new MembershipType { Name = "Annually", SignUpFee = 150, DurationInMonths = 12, DiscountRate = 20 }
                    );
                }

                if (!context.Genres.Any())
                {
                    context.Genres.AddRange(
                        new Genre { Id = 1, Name = "Thriller" },
                        new Genre { Id = 2, Name = "Document" },
                        new Genre { Id = 3, Name = "Comedy" }
                    );
                }


                if (!context.Books.Any())
                {
                    context.Books.AddRange(
                        new Book { Title = "Book 1", Author = "Author 1", GenreId = 1, DateAdded = DateTime.Now, NumberInStock = 3},
                        new Book { Title = "Book 2", Author = "Author 2", GenreId = 2, DateAdded = DateTime.Now, NumberInStock = 1},
                        new Book { Title = "Book 3", Author = "Author 3", GenreId = 3, DateAdded = DateTime.Now, NumberInStock = 2}
                    );
                }

                context.SaveChanges();
            }
        }
    }
}
