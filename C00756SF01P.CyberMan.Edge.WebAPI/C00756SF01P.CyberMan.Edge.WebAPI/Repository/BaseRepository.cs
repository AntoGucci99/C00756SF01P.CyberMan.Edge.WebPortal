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
            //Set.AsNoTracking();
            Set = context.Set<TEntity>();
            this.context = context;
        }

        public void Delete(int id)
        {
            //Set.AsNoTracking();
            var entity = Set.SingleOrDefault(x => x.Id == id);
            Set.Remove(entity);
        }
        public IEnumerable<TEntity> GetAll()
        {
            return Set.AsNoTracking().ToList();
        }

        public TEntity GetByID(int id)
        {
            //Set.AsNoTracking();
            return Set.SingleOrDefault(x => x.Id == id);
        }

        public void Insert(TEntity entity)
        {
            //Set.AsNoTracking();
            Set.Add(entity);
        }

        public void Update(TEntity entityToUpdate)
        {
            //Set.AsNoTracking();
            Set.Update(entityToUpdate);
            Set.SingleOrDefault(x => x.Id == entityToUpdate.Id).ModifiedAt = DateTime.Now;
        }
        public void SaveAll()
        {
            context.SaveChanges();
        }
    }
}
