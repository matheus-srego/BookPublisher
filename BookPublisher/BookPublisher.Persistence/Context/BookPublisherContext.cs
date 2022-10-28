using BookPublisher.Domain.Models;
using BookPublisher.Persistence.Mappers;
using Microsoft.EntityFrameworkCore;

namespace BookPublisher.Persistence.Context
{
    public class BookPublisherContext : DbContext
    {
        protected DbSet<AuthorModel> Author { get; set; }
        protected DbSet<BookModel> Book { get; set; }

        public BookPublisherContext(DbContextOptions<BookPublisherContext> options) : base(options)
        {
            // ---
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AuthorModel>(new AuthorMapper().Configure);
            modelBuilder.Entity<BookModel>(new BookMapper().Configure);
            modelBuilder.Entity<BookAuthorModel>(new BookAuthorMapper().Configure);
        }
    }
}
