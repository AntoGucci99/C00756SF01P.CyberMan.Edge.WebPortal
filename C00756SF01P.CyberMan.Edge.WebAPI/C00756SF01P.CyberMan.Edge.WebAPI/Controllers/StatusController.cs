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
        public ActionResult<IEnumerable<Status>> GetStatues()
        {
            var statues = UnitOfWork.StatusRepository.GetAll();
            if (statues != null)
            {
                return Ok(statues);
            }
            else
            {
                return BadRequest("There isn't statues");
            }
        }

        // GET: api/StatusControllerr/5
        [HttpGet("statusid/{id}", Name = "GetStatusById")]
        public ActionResult<Status> GetByIdStatus(int id)
        {           
                var result = UnitOfWork.StatusRepository.GetByID(id);
                if (result == null)
                {
                    return BadRequest("The status not exists");
                }
                else if (result.IsDeleted == true)
                {
                    return BadRequest("The status insert is deleted and you can access it");
                }
                else
                {
                    return Ok(result);
                }       
        }

        [HttpGet("machineid/{id}", Name = "GetStatusByMachineID")]
        //metodo con await e async
        public async Task<ActionResult<List<Status>>> GetStatusByIdMachine(int id)
        {
            var result = await UnitOfWork.StatusRepository.GetStatusByIDMachine(id);
            if (result.Count==0)
            {
                return BadRequest("IdMacchina not exists or not have statuses");
            }
            else
            {
                return Ok(result);
            }

        }
        [HttpGet("laststatudbymachineid/{id}", Name = "GetLastStatusByMachineId")]
        //metodo con await e async
        public async Task<ActionResult<Task<Status>>> GetLastStatusByIDMachineAsync(int id)
        {
            var result = await UnitOfWork.StatusRepository.GetLastStatusByIDMachine(id);
            if (result==null)
            {
                return BadRequest("IdMacchina not exists or not have status");
            }
            else
            {
                return Ok(result);
            }

        }
        [HttpGet("StatusName")]
        public async Task<ActionResult<List<string>>> GetStatusName()
        {
            var statusName = await UnitOfWork.StatusRepository.GetNameStatus();
            if (statusName != null)
            {
                return Ok(statusName);
            }
            else
            {
                return BadRequest("there isn't statues");
            }
            
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
            if (statusDeleted == null)
            {
                return BadRequest("Status insert not exists");
            }
            else
            {
                UnitOfWork.StatusRepository.SaveAll();
                return Ok(statusDeleted);
            }
            


        }
    }

}
