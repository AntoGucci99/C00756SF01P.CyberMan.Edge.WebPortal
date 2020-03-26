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
        private readonly AppContext context;

        public DbSet<TEntity> Set { get; }

        public BaseRepository(AppContext context)
        {
            //Set.AsNoTracking();
            this.context = context;
            Set = context.Set<TEntity>();
            
        }

        public void Delete(int id)
        {
            //Set.AsNoTracking();
            var entity = Set.SingleOrDefault(x => x.Id == id);
            entity.IsDeleted = true;
        }
        public IEnumerable<TEntity> GetAll()
        {
             return Set.AsNoTracking().Where(x => x.IsDeleted == false).ToList();
            
        }

        public TEntity GetByID(int id)
        {
            //Set.AsNoTracking();
            var result= Set.SingleOrDefault(x => x.Id == id);
            return result;
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
