using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TesteTecnico.Domain.Entities;

namespace TesteTecnico.Domain.Core.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        TEntity GetById(int Id);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity entity);
        void Remove(TEntity entity);
    }
}
