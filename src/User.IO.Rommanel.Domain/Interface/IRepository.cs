using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using User.IO.Rommanel.Domain.Core.Models;

namespace User.IO.Rommanel.Domain.Interface
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity<TEntity>
    {
        void Add(TEntity obj);
        void Update(TEntity obj);
        void Delete(Guid Id);
        IEnumerable<TEntity> Search(Expression<Func<TEntity, bool>> predicate);
        TEntity GetById(Guid id);
        IEnumerable<TEntity> GetAll();
        int SaveChanges();
    }
}
