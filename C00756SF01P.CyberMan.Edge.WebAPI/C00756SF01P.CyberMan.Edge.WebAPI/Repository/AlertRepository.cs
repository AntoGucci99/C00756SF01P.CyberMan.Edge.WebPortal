using C00756SF01P.CyberMan.Edge.WebAPI.Data.Entities;
using C00756SF01P.CyberMan.Edge.WebAPI.Repository.C00756SF01P.CyberMan.Edge.WebAPI.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C00756SF01P.CyberMan.Edge.WebAPI.Repository
{
    public class AlertRepository: BaseRepository<Alert>, IAlertRepository
    {
        private readonly AppContext Context;


        public AlertRepository(AppContext context) : base(context)
        {
            Context = context;
        }
        

        public async Task<List<Alert>> GetAlertByIDMachine(int id)
        {
            var listAlert = Set.Where(x => x.MachineId == id && x.IsDeleted == false);
            if (listAlert == null)
            {
                return null;
            }
            else
            {
                return await listAlert.Where(x => x.IsDeleted == false).ToListAsync(); 
            }
            
            //else
            //{

            //    return await listAlert.Where(x => x.IsDeleted == false).ToListAsync();
            //}
        }
        public async Task<Alert> GetLastAlertByIDMachine(int id)
        {
            var listAlert = Set.Where(x => x.MachineId == id && x.IsDeleted == false);
            if (listAlert == null)
            {
                return null;
            }
            else
            {
               
               return await listAlert.OrderByDescending(o => o.ModifiedAt).FirstOrDefaultAsync();
                //return await listAlert.MaxAsync(o=>o.ModifyAt);
                
            }
        }


    }
}
