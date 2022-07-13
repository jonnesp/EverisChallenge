using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EverisChallenge.Business.Models
{
    public class RefitCustomer
    {
        public slip slip { get; set; }
    }
    public class slip
    {
        public int id { get; set; }
        public string advice { get; set; }
    }
}
