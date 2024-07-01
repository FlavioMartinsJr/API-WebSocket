using Application.DTOs.Chat;
using Application.DTOs.Usuario;
using Application.Interfaces;
using AutoMapper;
using Domain.EntitiesConfigs;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;
        private readonly IMapper _mapper;
        public UsuarioService(IUsuarioRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UsuarioPost> AtualizarUsuarioLogout(int id)
        {
            var usuarios = await _repository.UpdateUsuarioLogout(id);
            var usuarioPut = _mapper.Map<UsuarioPost>(usuarios);
            return usuarioPut;
        }

        public async Task<IEnumerable<UsuarioGet>> BuscarUsuario()
        {
            var usuarios = await _repository.GetAllUsuario();
            var usuarioGets = _mapper.Map<IEnumerable<UsuarioGet>>(usuarios);
            return usuarioGets;
        }

        public async Task<UsuarioGet> BuscarUsuarioLogin(string nome, string senha)
        {
            var usuarios = await _repository.GetUsuarioLogin(nome,senha);
            var usuarioGets = _mapper.Map<UsuarioGet>(usuarios);
            return usuarioGets;
        }

        public async Task<UsuarioGet> BuscarUsuarioPorId(int id)
        {
            var usuarios = await _repository.GetUsuarioById(id);
            var usuarioGets = _mapper.Map<UsuarioGet>(usuarios);
            return usuarioGets;
        }

        public async Task<IEnumerable<UsuarioGet>> BuscarUsuarioPorTermo(string text)
        {
            var usuarios = await _repository.GetAllUsuarioBySearch(text);
            var usuarioGets = _mapper.Map<IEnumerable<UsuarioGet>>(usuarios);
            return usuarioGets;
        }
        public async Task<ChatPost> AdicionarChat(ChatPost mensagem)
        {
            var chatPost = _mapper.Map<TblChat>(mensagem);
            var chatIncluido = await _repository.PostChat(chatPost);
            return _mapper.Map<ChatPost>(chatIncluido);
        }

        public async Task<IEnumerable<ChatGet>> BuscarChat(int UsuarioRecebidoId, int UsuarioEnviadoId)
        {
            var chat = await _repository.GetAllChat(UsuarioRecebidoId, UsuarioEnviadoId);
            var chatGet = _mapper.Map<IEnumerable<ChatGet>>(chat);
            return chatGet;
        }
    }
}
