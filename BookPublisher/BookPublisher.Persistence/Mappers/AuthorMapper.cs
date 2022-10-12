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
    public class AuthorMapper : IEntityTypeConfiguration<AuthorModel>
    {
        public void Configure(EntityTypeBuilder<AuthorModel> builder)
        {
            builder.ToTable("autor");

            builder.HasKey(model => model.Id);

            builder.Property(model => model.Id)
                   .HasColumnName("id")
                   .ValueGeneratedNever()
                   .IsRequired();

            builder.Property(model => model.Name)
                   .HasColumnName("nome")
                   .ValueGeneratedNever()
                   .IsRequired();

            builder.Property(model => model.LastName)
                   .HasColumnName("sobrenome")
                   .ValueGeneratedNever()
                   .IsRequired();

            builder.Property(model => model.Email)
                   .HasColumnName("email")
                   .ValueGeneratedNever()
                   .IsRequired();

            builder.Property(model => model.Birthdate)
                   .HasColumnName("data_nascimento")
                   .ValueGeneratedNever()
                   .IsRequired();
        }
    }
}
