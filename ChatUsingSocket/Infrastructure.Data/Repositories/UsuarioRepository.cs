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
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _context;

        public UsuarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TblUsuario>> GetAllUsuario()
        {
            var query = _context.Usuario.OrderByDescending(x => x.Ativo).ToListAsync();
            return await query;
        }

        public async Task<IEnumerable<TblUsuario>> GetAllUsuarioBySearch(string text)
        {
            
            if (text == null)
            {
                 
                return await GetAllUsuario();
            }

            var query = from user in _context.Usuario
                        where user.Nome.Contains(text)
                        orderby user.Ativo descending
                        select user;
                       

            var result = await query.ToListAsync();
            return result!;
        }

        public async Task<TblUsuario> GetUsuarioById(int id)
        {
            var query = await _context.Usuario.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return query!;
        }

        public async Task<TblUsuario> GetUsuarioLogin(string nome, string senha)
        {
            
            var query = from user in _context.Usuario
                        where user.Nome == nome && user.Senha == senha
                        select user;

            var result =  await query.AsNoTracking().FirstOrDefaultAsync();

            if(result != null)
            {
                result.UpdateLogin();
                _context.Usuario.Update(result);
                await _context.SaveChangesAsync();
                return result;
            }

            return result!;
        }

        public async Task<TblUsuario> UpdateUsuarioLogout(int id)
        {
            var query = await _context.Usuario.FindAsync(id);

            if (query != null)
            {
                query.UpdateLogout();
                _context.Usuario.Update(query);
                await _context.SaveChangesAsync();
                return query;
            }

            return query!;
        }
        public async Task<IEnumerable<TblChat>> GetAllChat(int UsuarioRecebidoId, int UsuarioEnviadoId)
        {
           
            var query = from user in _context.Usuario 
                        join chat in _context.Chat 
                        on user.Id equals chat.UsuarioEnviadoId
                        where chat.UsuarioEnviadoId == UsuarioEnviadoId && chat.UsuarioRecebidoId == UsuarioRecebidoId  || chat.UsuarioEnviadoId == UsuarioRecebidoId && chat.UsuarioRecebidoId == UsuarioEnviadoId
                        select chat;


            return await query.ToListAsync();
        }

        public async Task<TblChat> PostChat(TblChat mensagem)
        {
            
            _context.Chat.Add(mensagem);
            await _context.SaveChangesAsync();
            return mensagem!;
         
        }
    }
}
