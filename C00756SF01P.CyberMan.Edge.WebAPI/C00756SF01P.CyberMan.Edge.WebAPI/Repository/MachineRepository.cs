using C00756SF01P.CyberMan.Edge.WebAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C00756SF01P.CyberMan.Edge.WebAPI.Repository
{
    public class MachineRepository: BaseRepository<Machine>, IMachineRepository
    {
        private readonly AppContext Context;


        public MachineRepository(AppContext context) : base(context)
        {
            Context = context;
        }
    }
}
