
using System.Collections.Generic;
using System.Threading.Tasks;

namespace C00756SF01P.CyberMan.Edge.WebAPI.Repository
{

    namespace C00756SF01P.CyberMan.Edge.WebAPI.Repository
    {
        public interface IStatusRepository : IRepository<Status>
        {
            public Task<List<Status>> GetStatusByIDMachine(int id);
            public Task<Status> GetLastStatusByIDMachine(int id);
            public Task<List<string>> GetNameStatus();
        }
    }
}
