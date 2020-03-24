using C00756SF01P.CyberMan.Edge.WebAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C00756SF01P.CyberMan.Edge.WebAPI.Repository
{
    interface IAlertRepository:IRepository<Alert>
    {
        public Task<List<Alert>> GetAlertByIDMachine(int id);
        public Task<Alert> GetLastAlertByIDMachine(int id);
    }
}
