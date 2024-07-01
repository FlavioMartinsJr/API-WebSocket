using Application.DTOs.Chat;
using Application.DTOs.Usuario;
using Domain.EntitiesConfigs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<UsuarioGet> BuscarUsuarioPorId(int id);
        Task<IEnumerable<UsuarioGet>> BuscarUsuario();
        Task<IEnumerable<UsuarioGet>> BuscarUsuarioPorTermo(string text);
        Task<UsuarioGet> BuscarUsuarioLogin(string nome, string senha);
        Task<UsuarioPost> AtualizarUsuarioLogout(int id);
        Task<IEnumerable<ChatGet>> BuscarChat(int UsuarioRecebidoId, int UsuarioEnviadoId);
        Task<ChatPost> AdicionarChat(ChatPost mensagem);
    }
}
