using Microsoft.EntityFrameworkCore;
using ZadanieTestowe.Extensions;
using ZadanieTestowe.Models;

namespace ZadanieTestowe;

public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.SeedData();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase(databaseName: "AppDb");
    }

    public DbSet<Campaign> Campaigns { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Keyword> Keywords { get; set; }
    public DbSet<Town> Towns { get; set; }
}