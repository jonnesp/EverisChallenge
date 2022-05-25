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
    public class TelefoneRepository : BaseRepository<Telefone>, ITelefoneRepository
    {
        public TelefoneRepository(MeuDbContext context) : base(context) { }

        public async Task AdicionarTelefones(List<Telefone> tel)
        {
            DbSet.AddRange(tel);
            await Db.SaveChangesAsync();
        }
    }
}
