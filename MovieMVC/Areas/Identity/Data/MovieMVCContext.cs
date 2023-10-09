using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieMVC.Areas.Identity.Data;
using MovieMVC.Models;

namespace MovieMVC.Data;

public class MovieMVCContext : IdentityDbContext<MovieMVCUser>
{
    public MovieMVCContext(DbContextOptions<MovieMVCContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        builder.Entity<Category>().HasData(new Category { Id = 1, CategoryName = "Drama" });
        builder.Entity<Category>().HasData(new Category { Id = 2, CategoryName = "Action" });
        builder.Entity<Category>().HasData(new Category { Id = 3, CategoryName = "Family" });
        builder.Entity<Category>().HasData(new Category { Id = 4, CategoryName = "Commedy" });
        builder.Entity<Category>().HasData(new Category { Id = 5, CategoryName = "Animation" });
        builder.Entity<Category>().HasData(new Category { Id = 6, CategoryName = "Crime" });
        builder.Entity<Category>().HasData(new Category { Id = 7, CategoryName = "Fantasy" });
        builder.Entity<Category>().HasData(new Category { Id = 8, CategoryName = "Historical" });
        builder.Entity<Category>().HasData(new Category { Id = 9, CategoryName = "Horror" });
        builder.Entity<Category>().HasData(new Category { Id = 10, CategoryName = "Romance" });
    }
    public DbSet<MovieMVC.Models.Post> Posts { get; set; }
    public DbSet<MovieMVC.Models.Category> Categories { get; set; }
}
