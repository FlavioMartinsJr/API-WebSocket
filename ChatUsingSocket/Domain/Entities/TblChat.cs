using Domain.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.EntitiesConfigs;

public class TblChat
{
    [Key]
    public int Id { get; set; }

    public string? MensagemRecebida { get; set; }

    public string? MensagemEnviada { get; set; }

    public int? UsuarioRecebidoId { get; set; }

    public int? UsuarioEnviadoId { get; set; }

    public bool? Ativo { get; set; }

    public TblUsuario? UsuarioEnviado { get; set; }

    public TblUsuario? UsuarioRecebido { get; set; }

    public TblChat(int id, string? mensagemRecebida, string? mensagemEnviada, int? usuarioRecebidoId, int? usuarioEnviadoId, bool? ativo )
    {
        DomainExceptionValidation.When(id < 0, "O id tem que ser positivo");
        Id = id;
        ValidateDomain(mensagemRecebida, mensagemEnviada, usuarioRecebidoId, usuarioEnviadoId, ativo);
    }
    public TblChat(string? mensagemRecebida, string? mensagemEnviada, int? usuarioRecebidoId, int? usuarioEnviadoId, bool? ativo)
    {
        ValidateDomain(mensagemRecebida, mensagemEnviada, usuarioRecebidoId, usuarioEnviadoId, ativo);
    }
    public void Update(string? mensagemRecebida, string? mensagemEnviada, int? usuarioRecebidoId, int? usuarioEnviadoId, bool? ativo)
    {
        ValidateDomain(mensagemRecebida, mensagemEnviada, usuarioRecebidoId, usuarioEnviadoId, ativo);
    }

    public void ValidateDomain(string? mensagemRecebida, string? mensagemEnviada, int? usuarioRecebidoId, int? usuarioEnviadoId, bool? ativo)
    {
        DomainExceptionValidation.When(usuarioRecebidoId < 0, "O usuarioRecebidoId tem que ser positivo");
        DomainExceptionValidation.When(usuarioEnviadoId < 0, "O usuarioEnviadoId tem que ser positivo");
        MensagemRecebida = mensagemRecebida;
        MensagemEnviada = mensagemEnviada;
        UsuarioRecebidoId = usuarioRecebidoId;
        UsuarioEnviadoId = usuarioEnviadoId;
        Ativo = ativo;
    }

}
