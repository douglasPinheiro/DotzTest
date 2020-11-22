using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TesteTecnico.Domain.Core.Interfaces.Repositories;
using TesteTecnico.Domain.Entities;

namespace TesteTecnico.Infra.Data.Repositories
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly ApplicationDbContext context;

        public BaseRepository(ApplicationDbContext Context)
        {
            context = Context;
        }
        public void Add(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
        }

        public int Count()
        {
            return context.Set<TEntity>().Count();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return context.Set<TEntity>().Where(predicate);
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return context.Set<TEntity>().FirstOrDefault(predicate);
        }

        public TEntity GetById(int Id)
        {
            return context.Set<TEntity>().FirstOrDefault(x => x.Id == Id);
        }

        public IEnumerable<TEntity> List()
        {
            return context.Set<TEntity>();
        }

        public void Remove(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
        }
    }
}
