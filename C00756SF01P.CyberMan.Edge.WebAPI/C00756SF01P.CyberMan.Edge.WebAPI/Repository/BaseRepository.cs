using C00756SF01P.CyberMan.Edge.WebAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
//using System.Data.Entity;

namespace C00756SF01P.CyberMan.Edge.WebAPI.Repository
{


    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : EntityBase
    {
        private readonly DbContext context;

        public DbSet<TEntity> Set { get; }

        public BaseRepository(DbContext context)
        {
            Set = context.Set<TEntity>();
            this.context = context;
        }

        public void Delete(int id)
        {
            var entity = Set.SingleOrDefault(x => x.Id == id);
            Set.Remove(entity);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Set.ToList();
        }

        public TEntity GetByID(int id)
        {
            return Set.SingleOrDefault(x => x.Id == id);
        }

        public void Insert(TEntity entity)
        {
            Set.Add(entity);
        }

        public void Update(TEntity entityToUpdate)
        {
            Set.Update(entityToUpdate);
        }
    }
}
