using EverisChallenge.Business.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EverisChallenge.Business.Interfaces
{
    public interface IRefitConsumeApi
    {
        

        [Get("/api/funcionario/{id}")]
        Task<FuncionarioApi> GetFuncionario(string id, [Header("Header-A")] string a, [Header("Header-B")] string b);

        
    }
}
