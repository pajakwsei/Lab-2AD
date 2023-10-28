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
                if (context.MembershipTypes.Any())
                {
                    Console.WriteLine("Database already seeded");
                    return;
                }

                context.MembershipTypes.AddRange(
                    new MembershipType {  Id = 1, SignUpFee = 0, DurationInMonths = 0, DiscountRate = 0 },    
                    new MembershipType {  Id = 2, SignUpFee = 30, DurationInMonths = 3, DiscountRate = 5 },    
                    new MembershipType {  Id = 3, SignUpFee = 90, DurationInMonths = 6, DiscountRate = 10 },    
                    new MembershipType {  Id = 4, SignUpFee = 150, DurationInMonths = 12, DiscountRate = 20 }    
                );

                context.SaveChanges();
            }
        }
    }
}
