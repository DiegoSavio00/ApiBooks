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
    public class BookImageMap : IEntityTypeConfiguration<BookImage>
    {
        public void Configure(EntityTypeBuilder<BookImage> builder)
        {
            builder.ToTable("BookImage");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("IdImagem").UseIdentityColumn();
            builder.Property(x => x.BookId).HasColumnName("IdLivro");
            builder.Property(x => x.ImageBase).HasColumnName("ImagemBase");
            builder.Property(x => x.ImageUri).HasColumnName("ImagemUri");
            builder.HasOne(x => x.Book).WithMany(x => x.BookImages);
        }
    }
}
