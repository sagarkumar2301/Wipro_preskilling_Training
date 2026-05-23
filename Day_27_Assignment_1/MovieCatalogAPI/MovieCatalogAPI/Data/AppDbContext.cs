using Microsoft.EntityFrameworkCore;
using MovieCatalogAPI.Models;

namespace MovieCatalogAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Director> Directors { get; set; }
    }
}