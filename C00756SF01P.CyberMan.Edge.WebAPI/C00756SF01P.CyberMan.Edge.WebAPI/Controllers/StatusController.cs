using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using C00756SF01P.CyberMan.Edge.WebAPI.Repository;
using C00756SF01P.CyberMan.Edge.WebAPI.Repository.C00756SF01P.CyberMan.Edge.WebAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Web;

namespace C00756SF01P.CyberMan.Edge.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        public UnitOfWork UnitOfWork { get; set; }
        public StatusController(UnitOfWork unit)
        {
            this.UnitOfWork = unit;
        }
        //public StatusController()
        //{
        //    UnitOfWork = new StatusRepository(new AppContext());
        //}
        //public StatusController(IStatusRepository IStatusRepository)
        //{
        //    UnitOfWork = IStatusRepository;
        //}

        // GET: api/StatusControllerr
        [HttpGet]
        public IEnumerable<Status> GetStatues()
        {
            return UnitOfWork.StatusRepository.GetAll();
        }

        // GET: api/StatusControllerr/5
        [HttpGet("{id}", Name = "GetByIdStatus")]
        public Status GetByIdStatus(int id)
        {
            return UnitOfWork.StatusRepository.GetByID(id);
        }
        // POST: api/StatusControllerr
        [HttpPost]
        public void PostStatus([FromBody] Status status)
        {
            UnitOfWork.StatusRepository.Insert(status);
            UnitOfWork.StatusRepository.SaveAll();
        }

        // PUT: api/StatusControllerr/5
        [HttpPut("{id}")]
        public void PutStatus(int id, [FromBody] Status status)
        {
            if (id == status.Id)
            {
                UnitOfWork.StatusRepository.Update(status);
                UnitOfWork.StatusRepository.SaveAll();
            }
            else
            {
                BadRequest();
            }
            
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void DeleteStatus(int id)
        {
            UnitOfWork.StatusRepository.Delete(id);
            UnitOfWork.StatusRepository.SaveAll();
        }
    }
}
