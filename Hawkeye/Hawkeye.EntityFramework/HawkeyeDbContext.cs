using Hawkeye.Domain.Models;
using Hawkeye.EntityFramework.Services;
using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;

namespace Hawkeye.EntityFramework
{
    public class HawkeyeDbContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Comment> Comments { get; set; }


        public HawkeyeDbContext(DbContextOptions<HawkeyeDbContext> options) : base(options) 
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var options = new DbContextOptionsBuilder<HawkeyeDbContext>();
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=HawkeyeDB;Trusted_Connection=True;");
            base.OnConfiguring(optionsBuilder);
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Playlists)
                .WithOne(p => p.User);

            modelBuilder.Entity<Role>()
                .HasMany(r => r.Users)
                .WithOne(u => u.Role)
                .HasForeignKey(u => u.RoleId);


            modelBuilder.Entity<Playlist>()
                .HasMany(p => p.Films)
                .WithMany(f => f.Playlists);

            modelBuilder.Entity<Film>()
                .HasMany(f => f.Comments)
                .WithOne(c => c.Film);

            modelBuilder.Entity<User>()
                .HasMany(u => u.FavoriteFilms)
                .WithMany(f => f.LikedUsers);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany(u => u.Comments);


            modelBuilder.Entity<User>().Property(u => u.RegistrationDate).HasDefaultValueSql("getdate()");


            

        }
    }
}
