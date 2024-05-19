using Microsoft.EntityFrameworkCore;

namespace BakeryWebSite.Models
{
    public class BakeryContext: DbContext
    {
        public DbSet<Good> Goods { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Component> Components { get; set; }
        public DbSet<Composition> Composition { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Good_in_stock> Good_In_Stocks { get; set; }
        public DbSet<Order_composition> Order_Compositions { get; set; }

        public BakeryContext(DbContextOptions options): base(options) 
        {
            Database.EnsureCreated();
        }
    }
}
