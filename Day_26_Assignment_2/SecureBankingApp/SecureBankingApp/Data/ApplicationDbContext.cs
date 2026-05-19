using Microsoft.EntityFrameworkCore;
using SecureBankingApp.Models;

namespace SecureBankingApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<AuditLog> AuditLogs { get; set; }
    }
}