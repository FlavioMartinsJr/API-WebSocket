using Domain.EntitiesConfigs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.DTOs.Chat
{
    public class ChatPost
    {
        public int Id { get; set; }

        public string? MensagemRecebida { get; set; }

        public string? MensagemEnviada { get; set; }

        [Required(ErrorMessage = "O UsuarioRecebidoId é obrigatório")]
        public int? UsuarioRecebidoId { get; set; }

        [Required(ErrorMessage = "O UsuarioEnviadoId é obrigatório")]
        public int? UsuarioEnviadoId { get; set; }

        public bool? Ativo { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public TblUsuario? UsuarioEnviado { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public TblUsuario? UsuarioRecebido { get; set; }
    }
}
