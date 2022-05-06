using Hawkeye.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hawkeye.EntityFramework
{
    public class HawkeyeDbContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Actor> Actors { get; set; }

        public HawkeyeDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Playlists)
                .WithOne(p => p.User);

            modelBuilder.Entity<Role>()
                .HasMany(r => r.Users)
                .WithOne(u => u.Role);

            modelBuilder.Entity<Playlist>()
                .HasMany(p => p.Films)
                .WithMany(f => f.Playlists);

            modelBuilder.Entity<Film>()
                .HasMany(f => f.Actors)
                .WithMany(a => a.Films);

            modelBuilder.Entity<Film>()
                .HasMany(f => f.Comments)
                .WithOne(c => c.Film);

        }
    }
}
