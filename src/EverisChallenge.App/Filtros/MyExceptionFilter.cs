using EverisChallenge.Business.Interfaces;
using EverisChallenge.Business.Notificacoes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace EverisChallenge.App.Filtros
{
    public class MyExceptionFilter : IExceptionFilter
    {
        public INotificador Notificador { get; }

        public MyExceptionFilter(INotificador notificador)
        {
            Notificador = notificador;
        }

        

        public void OnException(ExceptionContext context)
        {

            Notificador.Handle(new Notificacao($"Erro ao processar requisição: {context.Exception.Message}"));

            var result = JsonConvert.SerializeObject(Notificador.ObterNotificacoes());


            context.Result = new JsonResult(result) { StatusCode = 500 };

        }
    }
}
