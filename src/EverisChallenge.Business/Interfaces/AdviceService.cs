using EverisChallenge.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EverisChallenge.Business.Interfaces
{
    public interface AdviceService
    {

        Task<AdviceModel> GetAdviceById(string id);

        Task<AdviceModel> GetAdvice();


    }
}
