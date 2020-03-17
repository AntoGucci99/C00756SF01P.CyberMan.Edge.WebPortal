using C00756SF01P.CyberMan.Edge.WebAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace C00756SF01P.CyberMan.Edge.WebAPI.Repository
{ 

    public interface IRepository<TEntity> where TEntity : EntityBase
    {        
        IEnumerable<TEntity> GetAll();            
        TEntity GetByID(int id);      
        void Insert(TEntity entity);
        void Update(TEntity entityToUpdate);
        void Delete(int id);
        void SaveAll();
    }
}
