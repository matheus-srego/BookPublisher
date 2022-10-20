using BookPublisher.Domain.Models;
using BookPublisher.Persistence.Mappers;
using Microsoft.EntityFrameworkCore;

namespace BookPublisher.Persistence.Context
{
    public class BookPublisherContext : DbContext
    {
        public BookPublisherContext(DbContextOptions<BookPublisherContext> options) : base(options)
        {
            // ---
        }

        protected DbSet<AuthorModel> Author { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AuthorModel>(new AuthorMapper().Configure);
        }
    }
}
