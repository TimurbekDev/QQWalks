using Microsoft.EntityFrameworkCore;
using QQWalks.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Image = QQWalks.Domain.Entities.Image;

namespace QQWalks.Data.DbContexts;

public class QQWalksDbContext:DbContext
{
    public QQWalksDbContext(DbContextOptions<QQWalksDbContext> options):base(options)
    {  }
    public DbSet<Difficulty> Difficulties { get; set; }
    public DbSet<Region> Regions { get; set; }
    public DbSet<Walk> Walks { get; set; }
    public DbSet<Image> Images { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Seed data for Difficulties
        // Easy, Medium, Hard
        var difficulties = new List<Difficulty>()
        {
            new Difficulty()
            {
                Id = Guid.Parse("54466f17-02af-48e7-8ed3-5a4a8bfacf6f"),
                Name = "Easy"
            },
            new Difficulty()
            {
                Id = Guid.Parse("ea294873-7a8c-4c0f-bfa7-a2eb492cbf8c"),
                Name = "Medium"
            },
            new Difficulty()
            {
                Id = Guid.Parse("f808ddcd-b5e5-4d80-b732-1ca523e48434"),
                Name = "Hard"
            }
        };
        modelBuilder.Entity<Difficulty>().HasData(difficulties);
    }
}
