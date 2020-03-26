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
            var list1 = Set.Where(x => x.MachineId == id);
            return await list1.Where(x => x.IsDeleted == false).ToListAsync();

        }
        public async Task<Alert> GetLastAlertByIDMachine(int id)
        {
            var query = from alert in Context.Set<Alert>()
                        join machine in Context.Set<Machine>()
                           on alert.MachineId equals machine.Id
                        where machine.Id == id
                        select alert;

            return await query.OrderByDescending(o => o.ModifiedAt).FirstOrDefaultAsync();
        }


    }
}
