using Domain.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.EntitiesConfigs;

public partial class TblUsuario
{


    [Key]
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Senha { get; set; } = null!;

    public string? Img { get; set; }

    public DateTime? DataCriacao { get; set; }

    public DateTime? DataAlteracao { get; set; }

    public bool? Ativo { get; set; }


    public ICollection<TblChat> TblChatUsuarioEnviado { get; set; } = new List<TblChat>();

    public ICollection<TblChat> TblChatUsuarioRecebido { get; set; } = new List<TblChat>();
    
    public TblUsuario(int id, string nome, string senha, string? img, DateTime? dataCriacao, DateTime? dataAlteracao, bool? ativo )
    {
        DomainExceptionValidation.When(id < 0, "O id tem que ser positivo");
        Id = id;
        ValidateDomain(nome,senha,img,dataCriacao,dataAlteracao,ativo );
    }
    public TblUsuario(string nome, string senha, string? img, DateTime? dataCriacao, DateTime? dataAlteracao, bool? ativo)
    {
       
        ValidateDomain(nome, senha, img, dataCriacao, dataAlteracao, ativo);
    }
   
    public void Update(string nome, string senha, string? img, DateTime? dataCriacao, DateTime? dataAlteracao, bool? ativo)
    {
        ValidateDomain(nome, senha, img, dataCriacao, dataAlteracao, ativo);
    }
    public void UpdateLogout()
    {
        Ativo = false;
        DataAlteracao = DateTime.Now;
    }
    public void UpdateLogin()
    {
        Ativo = true;
        DataAlteracao = DateTime.Now;
    }

    public void ValidateDomain(string nome, string senha, string? img, DateTime? dataCriacao, DateTime? dataAlteracao, bool? ativo)
    {
        Nome = nome;
        Senha = senha;
        Img = img;
        DataCriacao = dataCriacao;
        DataAlteracao = dataAlteracao;
        Ativo = ativo;
    }
}
