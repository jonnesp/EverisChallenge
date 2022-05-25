using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EverisChallenge.Business.Models
{
    public class Usuario : Entity
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public List<Telefone> Telefones = new List<Telefone>();
        public string Token { get; set; }
        public DateTime UltimoLogin { get; set; }


        public Usuario()
        {
            Id = Guid.NewGuid();
            DataCriacao = DateTime.Now;
            DataAtualizacao = DateTime.Now;
            UltimoLogin = DateTime.Now;

        }
    }
}
