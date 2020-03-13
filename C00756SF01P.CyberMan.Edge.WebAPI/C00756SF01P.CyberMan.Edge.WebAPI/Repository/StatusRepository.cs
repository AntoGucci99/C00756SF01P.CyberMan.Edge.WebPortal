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
    }
}
