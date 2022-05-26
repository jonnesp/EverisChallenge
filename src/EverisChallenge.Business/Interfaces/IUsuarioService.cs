using EverisChallenge.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EverisChallenge.Business.Interfaces
{
    public interface IUsuarioService
    {
        Task<Usuario> Adicionar(Usuario usuario);

        Task<Usuario> AutenticarUsuario(string email, string senha);



    }
}
