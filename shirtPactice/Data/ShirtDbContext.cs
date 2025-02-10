using Microsoft.EntityFrameworkCore;
using shirtPactice.Modal;

namespace shirtPactice.Data
{
    public class ShirtDbContext: DbContext
    {
        public ShirtDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        { }

        public DbSet<Shirt> Shirts { get; set; }
       protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Shirt>().HasData(
                 new Shirt
                 {
                     shirtId = 1,
                     shirtName = "T-Shirt",
                     shirtDescription = "A casual t-shirt",
                     gender = "Male",
                     size = 42,
                     shirtModel = "Model A"
                 },
                new Shirt
                {
                    shirtId = 2,
                    shirtName = "Polo Shirt",
                    shirtDescription = "A formal polo shirt",
                    gender = "Female",
                    size = 38,
                    shirtModel = "Model B"
                }
                );
        }


    }
}
