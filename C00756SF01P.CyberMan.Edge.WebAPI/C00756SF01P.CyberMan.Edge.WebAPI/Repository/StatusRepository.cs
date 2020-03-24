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
    public class StatusRepository : BaseRepository<Status>, IStatusRepository
    {
        private readonly AppContext Context;


        public StatusRepository(AppContext context) : base(context)
        {
            Context = context;
        }
        public async Task<List<Status>> GetStatusByIDMachine(int id)
        {
            return await Set.Where(x => x.MachineId == id).ToListAsync();
        }


        public  async Task<List<string>> GetNameStatus()
        {
            var query = await this.Context.Statuses.Select(p => p.StatusName)?.Distinct()?.ToListAsync();
            return query;    
               
        }

        public async Task<Status> GetLastStatusByIDMachine(int id)
        {
            var query =  from status in Context.Set<Status>() 
                         join machine in Context.Set<Machine>() 
                            on status.MachineId equals machine.Id 
                         where machine.Id == id    
                         select status;

            return await query.OrderByDescending(o => o.ModifiedAt).FirstOrDefaultAsync();
        }
        //testjoin
        //public void Test()
        //{
        //    var machineName = string.Empty;
        //    var query =
        //        from machines in Context.Set<Machine>()
        //        join status in Context.Set<Status>()
        //            on machines.Id equals status.MachineId
        //        where machines.MachineName == machineName
        //        select status;

        //    query = query.OrderBy(x => x.Machine);

        //    var list = query.ToList();
        //}
    }
}
