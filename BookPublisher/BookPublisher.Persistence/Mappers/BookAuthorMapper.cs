using BookPublisher.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BookPublisher.Persistence.Mappers
{
    public class BookAuthorMapper : IEntityTypeConfiguration<BookAuthorModel>
    {
        public void Configure(EntityTypeBuilder<BookAuthorModel> builder)
        {
            /*builder.ToTable("livro_x_autor");

            builder.HasKey(model => model.Id);

            builder.Property(model => model.Id)
                   .HasColumnName("id")
                   .ValueGeneratedOnAdd();

            builder.HasKey(model => new { model.BookId, model.AuthorId });

            builder.Property(model => model.AuthorId)
                   .HasColumnName("id_autor");

            builder.Property(model => model.BookId)
                   .HasColumnName("id_livro");*/
        }
    }
}
