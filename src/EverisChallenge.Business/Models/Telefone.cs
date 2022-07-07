using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EverisChallenge.Business.Models
{
    public class Telefone : Entity
    {

        public String UsuarioId { get; set; }

        public string Numero { get; set; }

        public string DDD { get; set; }

        public Usuario Usuario { get; set; }

        public Telefone()
        {
            Id = Guid.NewGuid().ToString();
            DataCriacao = DateTime.UtcNow;
            DataAtualizacao = DateTime.UtcNow;
        }
    }
}
