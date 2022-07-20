using EverisChallenge.Business.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EverisChallenge.Business.Interfaces
{
    public interface IAdvice
    {

        [Get("/advice/{id}")]
        Task<AdviceModel> GetAdviceById(string id);

        [Get("/advice")]
        Task<AdviceModel> GetAdvice();
    }
}
