using Domain.EntitiesConfigs;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.EntitiesConfigs
{
    public class ChatConfiguration : IEntityTypeConfiguration<TblChat>
    {
        public void Configure(EntityTypeBuilder<TblChat> builder)
        {
            builder.ToTable("tb_chat");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.MensagemEnviada).IsUnicode(false).HasColumnName("mensagemEnviada");
            builder.Property(x => x.MensagemRecebida).IsUnicode(false).HasColumnName("mensagemRecebida");
            builder.Property(x => x.UsuarioEnviadoId).HasColumnName("userEnviado");
            builder.Property(x => x.UsuarioRecebidoId).HasColumnName("userRecebido");
            builder.Property(x => x.Ativo).HasDefaultValue(true).HasColumnName("ativo");
            builder.HasOne(x => x.UsuarioEnviado).WithMany(x => x.TblChatUsuarioEnviado).HasForeignKey(d => d.UsuarioEnviadoId).HasConstraintName("FK_Chat_UserEnviado");
            builder.HasOne(x => x.UsuarioRecebido).WithMany(x => x.TblChatUsuarioRecebido).HasForeignKey(d => d.UsuarioRecebidoId).HasConstraintName("FK_Chat_UserRecebido");
        }
    }
}
