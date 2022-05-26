using EverisChallenge.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EverisChallenge.Business.Interfaces
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task<TEntity> ObterPorId(Guid id);
        Task Adicionar(TEntity entity);
        Task Atualizar(TEntity entity);
        Task<int> SaveChanges();

    }
}
