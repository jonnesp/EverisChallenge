using EverisChallenge.Business.Interfaces;
using EverisChallenge.Business.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EverisChallenge.Service.Services
{
    public class RefitCustomerService : AdviceService
    {
        private readonly IAdvice RefitAdvice;

        public RefitCustomerService(IAdvice refitAdvice)
        {
            RefitAdvice = refitAdvice;
        }

 
        public async Task<AdviceModel> GetAdviceById(string id)
        {
            
            var result = await RefitAdvice.GetAdviceById(id);
            return result;
        }


        public async Task<AdviceModel> GetAdvice()
        {
           return await RefitAdvice.GetAdvice();
        }
    }
}
