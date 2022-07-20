using System.Collections.Generic;

namespace EverisChallenge.Business.Models
{
    public class RetornoSoVamu
    {
       public List<DataArray> Data { get; set; }

    }

    public class DataArray
    {
        public string Id { get; set; }

        public string Nome { get; set; }
    }

    public class FuncionarioApi
    {
        public string Id { get; set; }

        public string Nome { get; set; }
    }
}
