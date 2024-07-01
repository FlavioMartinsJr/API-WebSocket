using Domain.EntitiesConfigs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<TblUsuario> GetUsuarioById(int id);
        Task<IEnumerable<TblUsuario>> GetAllUsuario();
        Task<IEnumerable<TblUsuario>> GetAllUsuarioBySearch(string text);
        Task<TblUsuario> GetUsuarioLogin(string nome, string senha);
        Task<TblUsuario> UpdateUsuarioLogout(int id);
        Task<IEnumerable<TblChat>> GetAllChat(int UsuarioRecebidoId, int UsuarioEnviadoId);
        Task<TblChat> PostChat(TblChat mensagem);
    }

}
