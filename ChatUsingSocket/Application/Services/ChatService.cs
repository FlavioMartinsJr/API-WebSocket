using Application.DTOs.Chat;
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
    public class ChatService : IChatService
    {
        private readonly IChatRepository _repository;
        private readonly IMapper _mapper;
        public ChatService(IChatRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ChatPost> AdicionarChat(ChatPost mensagem)
        {
            var chatPost = _mapper.Map<TblChat>(mensagem);
            var chatIncluido = await _repository.PostChat(chatPost);
            return _mapper.Map<ChatPost>(chatIncluido);
        }

        public async Task<IEnumerable<ChatGet>> BuscarChat(int UsuarioRecebidoId, int UsuarioEnviadoId)
        {
            var chat = await _repository.GetAllChat(UsuarioRecebidoId,UsuarioRecebidoId);
            var chatGet = _mapper.Map<IEnumerable<ChatGet>>(chat);
            return chatGet;
        }
    }
}
