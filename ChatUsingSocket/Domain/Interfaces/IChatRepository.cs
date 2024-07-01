using Domain.EntitiesConfigs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IChatRepository
    {
        Task<IEnumerable<TblChat>> GetAllChat(int UsuarioRecebidoId, int UsuarioEnviadoId);
        Task<TblChat> PostChat(TblChat mensagem);
    }
}
