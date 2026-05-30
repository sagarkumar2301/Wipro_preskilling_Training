using Microsoft.EntityFrameworkCore;
using NoteVaultSecureAPI.Models;

namespace NoteVaultSecureAPI.Data
{

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    public DbSet<Note> Notes { get; set; }
}
}