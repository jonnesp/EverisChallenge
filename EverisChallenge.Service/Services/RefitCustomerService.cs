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
    public class RefitCustomerService : IRefitConsumeService
    {
        private readonly IRefitConsumeApi _customerService;
        private readonly string _apiUrl;

        public RefitCustomerService()
        {
            _apiUrl = "https://localhost:7144";
            _customerService = RestService.For<IRefitConsumeApi>(_apiUrl);
        }

        ////Advice Endpoint
        //public async Task<RefitCustomer> GetAsync()
        //{
        //    return await _customerService.GetAsync();
        //}

        //Api Endpoint
        public async Task<FuncionarioApi> GetFuncionario(string id)
        {
            string a = "Valor-A";
            string b = "Valor-B";
            return await _customerService.GetFuncionario(id, a, b);
        }

    }
}
