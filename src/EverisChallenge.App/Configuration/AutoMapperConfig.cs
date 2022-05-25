using AutoMapper;
using EverisChallenge.App.DTOs;
using EverisChallenge.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EverisChallenge.App.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Usuario, UsuarioCreateDtoResult>().ReverseMap();

            CreateMap<UsuarioCreateDto, Usuario>().ReverseMap();

            CreateMap<Telefone, TelefoneCreateDto>().ReverseMap();

            
                



        }

    }
}
