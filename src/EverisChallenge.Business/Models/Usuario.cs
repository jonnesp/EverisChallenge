using MongoDB.Bson;
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

        //Chamada pelo Endpoint de Usuario
        public Usuario()
        {
            Id = Guid.NewGuid().ToString();
            DataCriacao = DateTime.Now;
            DataAtualizacao = DateTime.Now;
            UltimoLogin = DateTime.Now;

        }

        //Chamada pelo Endpoint do mongoDB
        public Usuario(string nome, string email, string senha)
        {
            Id = ObjectId.GenerateNewId().ToString();
            Nome = nome;
            Email = email;
            Senha = senha;
            DataCriacao = DateTime.Now;
            DataAtualizacao = DateTime.Now;
            UltimoLogin = DateTime.Now;

        }
    }
}
