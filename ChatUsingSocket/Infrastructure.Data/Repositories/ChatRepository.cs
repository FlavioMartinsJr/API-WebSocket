using Domain.EntitiesConfigs;
using Domain.Interfaces;
using Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class ChatRepository : IChatRepository
    {
        private readonly ApplicationDbContext _context;

        public ChatRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TblChat>> GetAllChat(int UsuarioRecebidoId, int UsuarioEnviadoId)
        {
           /* var query = from chat in _context.Chat
                        where (chat.UsuarioEnviadoId == UsuarioEnviadoId && chat.UsuarioRecebidoId == UsuarioRecebidoId)
                        select chat;*/
           var query = from chat in _context.Chat
                       select chat;


            return await query.ToListAsync();
        }

        public async Task<TblChat> PostChat(TblChat mensagem)
        {
            var query = await _context.Chat.FindAsync(mensagem.UsuarioEnviadoId,mensagem.UsuarioRecebidoId);

            if (query != null)
            {
                _context.Chat.Add(mensagem);
                await _context.SaveChangesAsync();
                return mensagem!;
            }
            return null!;
        }
    }

}
