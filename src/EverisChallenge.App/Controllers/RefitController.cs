using EverisChallenge.Business.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EverisChallenge.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RefitController : MainController
    {
        private readonly IRefitConsumeService _refitConsumeService;
        private readonly IHttpContextAccessor _contextAccessor;
        public RefitController(INotificador notificador 
                               ,IRefitConsumeService refitConsumeService
                               ,IHttpContextAccessor httpContextAccessor) : base(notificador)
        {
            _refitConsumeService = refitConsumeService;
            _contextAccessor = httpContextAccessor;
        }



        //[HttpGet]
        //public async Task<ActionResult> GetAll()
        //{
        //    if (!ModelState.IsValid) return CustomResponse(ModelState);

        //    _contextAccessor.HttpContext.Request.Headers.Add("X-Salada", "É BOM");
        //    var result = await _refitConsumeService.GetAsync();

        //    return CustomResponse(result);
        //}

        [HttpGet("{id}")]
        public async Task<ActionResult> GetFuncionario(string id)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var meuHeader = _contextAccessor.HttpContext.Request.Headers["Teste"].ToString();
            _contextAccessor.HttpContext.Request.Headers.Add("X-Salada", "É BOM");
            
            var result = await _refitConsumeService.GetFuncionario(id);

            return CustomResponse(result);
        }


    }
}
