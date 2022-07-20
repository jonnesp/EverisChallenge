using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Threading.Tasks;

namespace EverisChallenge.App.Filtros
{
    public class ConfigureMongoFilter : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            Console.WriteLine("Antes de executar meu metodo");

            await next();

            Console.WriteLine("Depois de executar meu metodo");
        }
    }
}
