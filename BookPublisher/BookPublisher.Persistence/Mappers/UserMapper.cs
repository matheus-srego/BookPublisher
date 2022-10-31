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
    public class UserMapper : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            builder.ToTable("usuario");

            builder.HasKey(model => model.Id);

            builder.Property(model => model.Id)
                   .HasColumnName("id")
                   .ValueGeneratedOnAdd()
                   .IsRequired();

            builder.Property(model => model.Name)
                   .HasColumnName("nome")
                   .IsRequired();

            builder.Property(model => model.Email)
                   .HasColumnName("email")
                   .IsRequired();

            builder.Property(model => model.Password)
                   .HasColumnName("senha")
                   .IsRequired();
        }
    }
}
