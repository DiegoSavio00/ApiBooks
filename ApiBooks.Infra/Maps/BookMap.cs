using ApiBooks.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiBooks.Infra.Maps
{
    public class BookMap : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Book");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("BookId").UseIdentityColumn();
            builder.Property(x => x.Title).HasColumnName("Title");
            builder.Property(x => x.Author).HasColumnName("Author");
            builder.Property(x => x.Price).HasColumnName("Preco");
            builder.HasOne(x => x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CategoryId);
            builder.HasMany(x => x.BookImages).WithOne(x => x.Book).HasForeignKey(x => x.BookId);
        }
    }
}
