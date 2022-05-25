using AutoMapper;
using EverisChallenge.App.DTOs;
using EverisChallenge.Business;
using EverisChallenge.Business.Interfaces;
using EverisChallenge.Business.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EverisChallenge.App.Controllers
{
    [Route("[controller]")]
    public class UsuariosController : MainController
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;
        public UsuariosController(INotificador notificador,
                                IUsuarioService usuarioService) : base(notificador)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("signup")]
        public async Task<ActionResult> SignUp(UsuarioCreateDto registerUser) 
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var user = CriarUsuario(registerUser);

            await _usuarioService.Adicionar(user);

            return CustomResponse(CriarUsuarioResult(user));
        }


        private Usuario CriarUsuario(UsuarioCreateDto registerUser)
        {
            var user = new Usuario
            {
                Nome = registerUser.Nome,
                Email = registerUser.Email,
                Senha = registerUser.Senha,
                Token = "",
            };

            foreach (var tel in registerUser.Telefones)
            {
                var telefone = new Telefone();
                telefone.Numero = tel.Numero;
                telefone.UsuarioId = user.Id;
                telefone.DDD = tel.DDD;
                user.Telefones.Add(telefone);
            }

            return user;
        }

        private UsuarioCreateDtoResult CriarUsuarioResult(Usuario user)
        {
            var result = new UsuarioCreateDtoResult
            {
                Id = user.Id,
                Nome = user.Nome,
                Email = user.Email,
                Data_Criacao = user.DataCriacao,
                Data_Atualizacao = user.DataAtualizacao,
                Ultimo_Login = user.UltimoLogin,
                Token = user.Token
            };

            return result;
        }
    }
}
