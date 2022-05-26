using EverisChallenge.Business.Interfaces;
using EverisChallenge.Business.Models;
using EverisChallenge.Data.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EverisChallenge.Data.Repository
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly MeuDbContext Db;
        protected readonly DbSet<TEntity> DbSet;

        protected BaseRepository(MeuDbContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }


        public virtual async Task<TEntity> ObterPorId(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task Adicionar(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Atualizar(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }

    }
}
