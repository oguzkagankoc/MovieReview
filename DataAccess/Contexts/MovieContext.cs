using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Contexts
{
    public class MovieContext : DbContext

    {
        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Director> Directors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        {
            string connectionString = "server=DESKTOP-BSP44OQ;database=MovieReviewDbv2;Trusted_Connection=True;";


            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(user => user.Role)
                .WithMany(role => role.Users)
                .HasForeignKey(role => role.RoleId)
                .OnDelete(DeleteBehavior.NoAction)
                ;
            modelBuilder.Entity<Movie>()
                .HasOne(m => m.Director)
                .WithMany(d => d.Movies)
                .HasForeignKey(m => m.DirectorId)
                .OnDelete(DeleteBehavior.NoAction)
                ;
            modelBuilder.Entity<Director>()
                .HasMany(d => d.Movies)
                ;
            modelBuilder.Entity<Role>()
                .HasMany(r => r.Users)
                ;
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Movie)
                .WithMany(m => m.Comments)
                .HasForeignKey(m => m.MovieId)
                .OnDelete(DeleteBehavior.NoAction)
                ;
            modelBuilder.Entity<MovieGenre>()
                .HasKey(c => new { c.MovieId, c.GenreId })
                ;
            modelBuilder.Entity<Genre>()
                .HasMany(u => u.MovieGenres)
                .WithOne(mg => mg.Genre)
                .HasForeignKey(mg => mg.GenreId)
                .OnDelete(DeleteBehavior.NoAction)
                ;
        }
    }
}
