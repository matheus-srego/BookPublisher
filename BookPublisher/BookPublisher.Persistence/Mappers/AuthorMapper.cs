using BookPublisher.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
                   .ValueGeneratedOnAdd()
                   .IsRequired();

            builder.Property(model => model.Name)
                   .HasColumnName("nome")
                   .IsRequired();

            builder.Property(model => model.LastName)
                   .HasColumnName("sobrenome")
                   .IsRequired();

            builder.Property(model => model.Email)
                   .HasColumnName("email")
                   .IsRequired();

            builder.Property(model => model.Birthdate)
                   .HasColumnName("data_nascimento")
                   .IsRequired();

            builder.HasMany(model => model.BookAuthor)
                   .WithOne(model => model.Author)
                   .HasForeignKey(model => model.AuthorId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
