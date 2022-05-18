using EverisChallenge.App.DTOs;
using EverisChallenge.Business;
using EverisChallenge.Business.Interfaces;
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
        public UsuariosController(INotificador notificador) : base(notificador)
        {
        }

        [HttpPost("signup")]
        public async Task<ActionResult> SignUp(UsuarioCreateDto registerUser) 
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            return CustomResponse();
        }
    }
}
