using Domain.EntitiesConfigs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.DTOs.Usuario
{
    public class UsuarioGet
    {
        public int Id { get; set; }

        public string Nome { get; set; } = null!;

        [JsonIgnore]
        public string Senha { get; set; } = null!;

        public string? Img { get; set; }

        public DateTime? DataCriacao { get; set; }

        public DateTime? DataAlteracao { get; set; }

        public bool? Ativo { get; set; }     

        [JsonIgnore]
        [IgnoreDataMember]
        public ICollection<TblChat> TblChatUsuarioEnviado { get; set; } = new List<TblChat>();

        [JsonIgnore]
        [IgnoreDataMember]
        public ICollection<TblChat> TblChatUsuarioRecebido { get; set; } = new List<TblChat>();
    }
}
