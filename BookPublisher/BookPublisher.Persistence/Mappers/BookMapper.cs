using BookPublisher.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookPublisher.Persistence.Mappers
{
    public class BookMapper : IEntityTypeConfiguration<BookModel>
    {
        public void Configure(EntityTypeBuilder<BookModel> builder)
        {
            builder.ToTable("livro");

            builder.HasKey(model => model.Id);

            builder.Property(model => model.Id)
                   .HasColumnName("id")
                   .ValueGeneratedOnAdd()
                   .IsRequired();

            builder.Property(model => model.Title)
                   .HasColumnName("titulo")
                   .IsRequired();

            builder.Property(model => model.ISBN)
                   .HasColumnName("isbn")
                   .IsRequired();

            builder.Property(model => model.ReleaseYear)
                   .HasColumnName("ano_lancamento")
                   .IsRequired();

            builder.HasMany(model => model.BookAuthor)
                   .WithOne(model => model.Book)
                   .HasForeignKey(model => model.BookId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
