using Microsoft.EntityFrameworkCore;

namespace LocalBuisinessApi.Models
{
    public class LocalBuisinessApiContext : DbContext
    {
        public LocalBuisinessApiContext(DbContextOptions<LocalBuisinessApiContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
          builder.Entity<Restaurant>()
          .HasData(
              new Restaurant { RestaurantId = 1, Name = "Andy's Pizzeria", Address = "123 Fake Ave, Portland, OR", Cuisine = "Pizza", Rating = 3 },
              new Restaurant { RestaurantId = 2, Name = "Hot Sips Cafe", Address = "456 Fake Ave, Portland, OR", Cuisine = "Coffee/Pastries", Rating = 4 },
              new Restaurant { RestaurantId = 3, Name = "Rob's Burgers", Address = "789 Fake Ave, Portland, OR", Cuisine = "Burgers", Rating = 5 }
          );
          builder.Entity<Shop>()
          .HasData(
              new Shop { ShopId = 1, Name = "You can glue it!", Address = "123 Fake St, Seattle, WA", Specialty = "Crafts", Rating = 5 },
              new Shop { ShopId = 2, Name = "Danny's Grocery Store", Address = "123 Fake St, Seattle, WA", Specialty = "Groceries", Rating = 1 },
              new Shop { ShopId = 3, Name = "Jewelry Plus", Address = "123 Fake St, Seattle, WA", Specialty = "Jewelry", Rating = 2 }
          );
        }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Shop> Shops { get; set; }
    }
}
