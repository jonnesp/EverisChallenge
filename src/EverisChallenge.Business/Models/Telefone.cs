using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EverisChallenge.Business.Models
{
    public class Telefone : Entity
    {

        public Guid UsuarioId { get; set; }

        public string Numero { get; set; }

        public string DDD { get; set; }

        public Usuario Usuario { get; set; }
    }
}
