using Microsoft.EntityFrameworkCore;
using NZWalks.Models.Domain;

namespace NZWalks.Data
{
    public class NZWalksDbContext : DbContext
    {
        public NZWalksDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) 
        { 
                
        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var difficulties = new List<Difficulty>
            {
                new Difficulty
                {
                    Id = Guid.Parse("6102c45a-cbff-4806-8876-3fee437cf485"),
                    Name = "Easy"
                },
                new Difficulty
                {
                    Id = Guid.Parse("3704a19b-efe7-4cf5-8051-a88fd675eb9d"),
                    Name = "Medium"
                },
                new Difficulty
                {
                    Id = Guid.Parse("d0a80614-636b-48aa-a43b-5ec1a87f0e73"),
                    Name = "Hard"
                }
            };

            var regions = new List<Region>
            {
                new Region
                {
                    Id = Guid.Parse("531b20c2-822d-4df8-8469-2a8d3e5eeb77"),
                    Name = "Auckland",
                    Code = "AKL",
                    RegionImageUtrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQqqBV7oCy4YvUtmrLJesTWoOsPIi-7vssBDw&s"
                },
                new Region
                {
                    Id = Guid.Parse("b209acc1-305f-4058-88c2-aae307030405"),
                    Name = "Almaty",
                    Code = "ALA",
                    RegionImageUtrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS_Cp8ZXZ57NI1UN9Gw_9kuGsbO4jIPdhovJA&s"
                },
                new Region
                {
                    Id = Guid.Parse("672aa0a5-e0a3-41cd-872e-caacadf3b185"),
                    Name = "Tashkent",
                    Code = "TA",
                    RegionImageUtrl = "https://trvlland.com/wp-content/uploads/2022/09/uzbekistan_tashkent-3-1024x663.jpg"
                }
            };

            modelBuilder.Entity<Difficulty>().HasData(difficulties);
            modelBuilder.Entity<Region>().HasData(regions);
        }

    }
}
