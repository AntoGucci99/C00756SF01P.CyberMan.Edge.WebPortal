using C00756SF01P.CyberMan.Edge.WebAPI.Data.Entities;
using System;
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
    }
}
