using AutoMapper;
using EverisChallenge.App.DTOs;
using EverisChallenge.App.Extensions;
using EverisChallenge.Business;
using EverisChallenge.Business.Interfaces;
using EverisChallenge.Business.Models;
using EverisChallenge.Data.Contexto;
using EverisChallenge.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EverisChallenge.App.Controllers
{
    [Route("[controller]")]
    public class UsuariosController : MainController
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;


        public UsuariosController(INotificador notificador,
                                IUsuarioService usuarioService,
                                IMapper mapper, 
                                IHttpContextAccessor httpContext) : base(notificador)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
            _httpContext = httpContext;
        }

        [HttpGet("{id:Guid}")]
        [Authorize]
        public async Task<ActionResult> SearchById(Guid id)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var token = RecuperarToken();

            var result = await _usuarioService.Buscar(id, token);

            return CustomResponse(_mapper.Map<UsuarioCreateDtoResult>(result));
        }



        //[HttpGet]
        //public async Task<ActionResult> TestHttpContext()
        //{
        //    if (!ModelState.IsValid) return CustomResponse(ModelState);



        //    return Ok(token);
        //}

        


        [HttpPost("signup")]
        public async Task<ActionResult> SignUp(UsuarioCreateDto registerUser)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);


            var result = await _usuarioService.Adicionar(_mapper.Map<Usuario>(registerUser));

            return CustomResponse(_mapper.Map<UsuarioCreateDtoResult>(result));
        }

        [HttpPost("signin")]
        public async Task<ActionResult> AutenticarUsuario(UserLoginDto user)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            

            var result = await _usuarioService.AutenticarUsuario(user.Email, user.Senha);

            return CustomResponse(_mapper.Map<UsuarioCreateDtoResult>(result));
        }

        private string RecuperarToken()
        {
            var token = _httpContext.HttpContext.Request.Headers["Authorization"].ToString();

            return token.Substring(7);
        }







        //private Usuario CriarUsuario(UsuarioCreateDto registerUser)
        //{
        //    var user = new Usuario
        //    {
        //        Nome = registerUser.Nome,
        //        Email = registerUser.Email,
        //        Senha = registerUser.Senha,
        //        Token = "",
        //    };

        //    foreach (var tel in registerUser.Telefones)
        //    {
        //        var telefone = new Telefone();
        //        telefone.Numero = tel.Numero;
        //        telefone.UsuarioId = user.Id;
        //        telefone.DDD = tel.DDD;
        //        user.Telefones.Add(telefone);
        //    }

        //    return user;
        //}

        //private UsuarioCreateDtoResult CriarUsuarioResult(Usuario user)
        //{
        //    var result = new UsuarioCreateDtoResult
        //    {
        //        Id = user.Id,
        //        Nome = user.Nome,
        //        Email = user.Email,
        //        Data_Criacao = user.DataCriacao,
        //        Data_Atualizacao = user.DataAtualizacao,
        //        Ultimo_Login = user.UltimoLogin,
        //        Token = user.Token
        //    };

        //    return result;
        //}
    }
}
