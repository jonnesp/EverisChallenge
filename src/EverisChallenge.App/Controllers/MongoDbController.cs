using EverisChallenge.App.DTOs;
using EverisChallenge.Business.Interfaces;
using EverisChallenge.Business.Models;
using EverisChallenge.Data.Contexto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EverisChallenge.App.Controllers
{
    [Route("api/[controller]")]
    
    public class MongoDbController : MainController
    {
        private readonly MongoDbContext Context = new MongoDbContext();

        public MongoDbController(INotificador notificador) : base(notificador)
        {

        }

        [HttpPost]
        public async Task<ActionResult> SignUp(MongoDbCreate registerUser)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            Usuario userMongo = new Usuario(registerUser.Nome, registerUser.Email, registerUser.Senha);

            Context.Telefone.Insert(userMongo);

            return CustomResponse(userMongo);
        }

        //[HttpGet]
        //public async Task<ActionResult> GetAll()
        //{
        //    if (!ModelState.IsValid) return CustomResponse(ModelState);



        //    return CustomResponse(Context.Telefone.Find(_ => true).ToListAsync());

        //}

    }
}
