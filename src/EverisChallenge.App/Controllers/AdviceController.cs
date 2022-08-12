using EverisChallenge.Business.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EverisChallenge.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdviceController : MainController
    {
        private readonly AdviceService _adviceService;
        public AdviceController(INotificador notificador, AdviceService adviceService) : base(notificador)
        {
            _adviceService = adviceService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAdviceByID(string id)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _adviceService.GetAdviceById(id);

            return CustomResponse(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAdvice()
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _adviceService.GetAdvice();

            return CustomResponse(result);
        }
    }
}