using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using C00756SF01P.CyberMan.Edge.WebAPI.Repository;
using C00756SF01P.CyberMan.Edge.WebAPI.Repository.C00756SF01P.CyberMan.Edge.WebAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


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


        [HttpGet]
        public IEnumerable<Status> GetStatues()
        {
            return UnitOfWork.StatusRepository.GetAll();
        }

        // GET: api/StatusControllerr/5
        [HttpGet("statusid/{id}", Name = "GetStatusById")]
        public ActionResult<Status> GetByIdStatus(int id)
        {           
                var result = UnitOfWork.StatusRepository.GetByID(id);
                if (result.IsDeleted == true)
                {
                    return BadRequest("lo status inserit is deleted and you can access it");
                }
                return result;
        }

        [HttpGet("machineid/{id}", Name = "GetStatusByMachineID")]
        //metodo con await e async
        public async Task<ActionResult<List<Status>>> GetStatusByIdMachine(int id)
        {
            var result = await UnitOfWork.StatusRepository.GetStatusByIDMachine(id);
            if (result == null)
            {
                return BadRequest("idMacchina not exists or not have statuses");
            }
            else
            {
                return Ok(result);
            }

        }
        [HttpGet("laststatudbymachineid/{id}", Name = "GetLastStatusByMachineId")]
        //metodo con await e async
        public ActionResult<Task<Status>> GetLastStatusByIDMachine(int id)
        {
            var result = UnitOfWork.StatusRepository.GetLastStatusByIDMachine(id);
            if (result == null)
            {
                return BadRequest("idMacchina not exists or not have status");
            }
            else
            {
                return Ok(result);
            }

        }
        [HttpGet("StatusName")]
        public async Task<ActionResult<List<string>>> GetStatusName()
        {
            return Ok(await UnitOfWork.StatusRepository.GetNameStatus());
        }
        // POST: api/StatusControllerr
        [HttpPost]
        public ActionResult<Status> PostStatus([FromBody] Status status)
        {
                var statusInsert=UnitOfWork.StatusRepository.Insert(status);
                UnitOfWork.StatusRepository.SaveAll();
                return Ok(statusInsert);
        }

        // PUT: api/StatusControllerr/5
        [HttpPut("{id}")]
        public ActionResult<Status> PutStatus([FromBody] Status status)
        {

               var statusUpdate=UnitOfWork.StatusRepository.Update(status);
               UnitOfWork.StatusRepository.SaveAll();
               return Ok(statusUpdate);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<Status> DeleteStatus(int id)
        {
            var statusDeleted = UnitOfWork.StatusRepository.Delete(id);
            UnitOfWork.StatusRepository.SaveAll();
            return Ok(statusDeleted);


        }
    }

}
