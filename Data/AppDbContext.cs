using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class AppDbContext : DbContext
{
    public DbSet<ContactEntity> Contacts { get; set; }
    private string DbPath { get; set; }

    public AppDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "contacts.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options) =>
        options.UseSqlite($"Data Source={DbPath}");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ContactEntity>().HasData(
            new ContactEntity()
            {
                Id = 1, Name = "Adam", Email = "adam@wsei.edu.pl", Phone = "127813268163",
                Birth = new DateTime(2000, 10, 10)
            },
            new ContactEntity()
            {
                Id = 2, Name = "Ewa", Email = "ewa@wsei.edu.pl", Phone = "293443823478",
                Birth = new DateTime(1999, 8, 10)
            }
        );
    }
}