using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using C00756SF01P.CyberMan.Edge.WebAPI.Repository.C00756SF01P.CyberMan.Edge.WebAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace C00756SF01P.CyberMan.Edge.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private IStatusRepository isp;
        public StatusController(IStatusRepository isp)
        {
            this.isp = isp;
        }
        // GET: api/StatusControllerr
        [HttpGet]
        public IEnumerable<Status> Get()
        {
            return isp.GetAll();
        }

        // GET: api/StatusControllerr/5
        [HttpGet("{id}", Name = "Get")]
        public Status Get(int id)
        {
            return isp.GetByID(id);
        }

        // POST: api/StatusControllerr
        [HttpPost]
        public void Post([FromBody] Status status)
        {
            isp.Insert(status);
        }

        // PUT: api/StatusControllerr/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Status status)
        {
            if (id == status.Id)
            {
                isp.Update(status);
            }else
            {
                BadRequest();
            }
            
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            isp.Delete(id);
        }
    }
}
