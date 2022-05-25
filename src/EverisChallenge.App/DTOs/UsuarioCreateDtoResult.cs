using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EverisChallenge.App.DTOs
{
    public class UsuarioCreateDtoResult
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public DateTime Data_Criacao { get; set; }

        public DateTime Data_Atualizacao { get; set; }

        public DateTime Ultimo_Login { get; set; }

        public string Token { get; set; }
    }
}
