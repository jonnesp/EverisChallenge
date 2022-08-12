using AutoMapper;
using EverisChallenge.App.DTOs;
using EverisChallenge.Business.Interfaces;
using EverisChallenge.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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


       
    }
}
