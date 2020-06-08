using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using User.IO.Rommanel.Domain.Core.Models;
using User.IO.Rommanel.Domain.Interface;
using User.IO.Rommanel.Infra.Data.Context;

namespace User.IO.Rommanel.Infra.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity<TEntity>
    {
        protected UserContext Db;
        protected DbSet<TEntity> DbSet;

        protected Repository(UserContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public virtual void Add(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public virtual void Update(TEntity obj)
        {
            DbSet.Update(obj);
        }

        public virtual IEnumerable<TEntity> Search(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.AsNoTracking().Where(predicate);
        }

        public virtual TEntity GetById(Guid id)
        {
            return DbSet.AsNoTracking().FirstOrDefault(t => t.Id == id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return DbSet.ToList();
        }

        public virtual void Delete(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
