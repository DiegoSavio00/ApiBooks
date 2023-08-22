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
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Usuario");
            builder.HasKey(x => x.Id);
            builder.Property(u => u.Id).HasColumnName("IdUsuario").UseIdentityColumn();
            builder.Property(u => u.Email).HasColumnName("Email");
            builder.Property(u => u.Password).HasColumnName("Senha");
        }
    }
}
