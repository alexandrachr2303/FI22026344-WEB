using Microsoft.EntityFrameworkCore;
using LibreriaApp.Models;

namespace LibreriaApp.Data
{
    public class LibreriaContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TitleTag> TitlesTags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=data/books.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TitleTag>().ToTable("TitlesTags");

            modelBuilder.Entity<Title>().Property(t => t.TitleId).HasColumnOrder(0);
            modelBuilder.Entity<Title>().Property(t => t.AuthorId).HasColumnOrder(1);
            modelBuilder.Entity<Title>().Property(t => t.TitleName).HasColumnOrder(2);
        }
    }
}
