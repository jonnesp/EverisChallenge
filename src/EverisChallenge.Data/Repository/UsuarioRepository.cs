using EverisChallenge.Business.Interfaces;
using EverisChallenge.Business.Models;
using EverisChallenge.Data.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EverisChallenge.Data.Repository
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(MeuDbContext context) : base(context) {}

        public bool FindByEmailAsync(string email)
        {
            return DbSet.Select(x => x.Email).Where(m => m.Equals(email)).Any();
        }
    }
}
