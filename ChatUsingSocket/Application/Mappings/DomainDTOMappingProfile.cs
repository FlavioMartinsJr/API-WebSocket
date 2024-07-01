using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Application.DTOs.Usuario;
using Domain.EntitiesConfigs;
using Application.DTOs.Chat;

namespace Application.Mappings
{
    public class DomainDTOMappingProfile : Profile
    {
        public DomainDTOMappingProfile()
        {
            CreateMap<TblUsuario, UsuarioGet>().ReverseMap();
            CreateMap<TblUsuario, UsuarioPost>().ReverseMap();

            CreateMap<TblChat, ChatGet>().ReverseMap();
            CreateMap<TblChat, ChatPost>().ReverseMap();

        }
    }
}
