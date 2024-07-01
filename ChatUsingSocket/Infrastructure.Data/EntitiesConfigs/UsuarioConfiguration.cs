using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.EntitiesConfigs;

namespace Infrastructure.Data.EntitiesConfigs
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<TblUsuario>
    {
        public void Configure(EntityTypeBuilder<TblUsuario> builder)
        {
            builder.ToTable("tb_usuario");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Nome).HasMaxLength(255).IsUnicode(false).HasColumnName("nome");
            builder.Property(x => x.Senha).HasMaxLength(255).IsUnicode(false).HasColumnName("senha");
            builder.Property(x => x.Img).HasMaxLength(255).IsUnicode(false).HasColumnName("img");
            builder.Property(x => x.DataAlteracao).HasDefaultValueSql("(getdate())").HasColumnType("datetime").HasColumnName("dataAlteracao");
            builder.Property(x => x.DataCriacao).HasDefaultValueSql("(getdate())").HasColumnType("datetime").HasColumnName("dataCriacao"); ;
            builder.Property(x => x.Ativo).HasDefaultValue(true).HasColumnName("ativo");
        }
    }
}
