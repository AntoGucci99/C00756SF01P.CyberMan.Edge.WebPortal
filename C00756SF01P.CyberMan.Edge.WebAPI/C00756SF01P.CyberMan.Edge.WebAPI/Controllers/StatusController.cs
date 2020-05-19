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
            
            var status = UnitOfWork.StatusRepository.GetAll();
            return Ok(status);
        }

        // GET: api/StatusControllerr/5
        [HttpGet("statusid/{id}", Name = "GetStatusById")]
        public ActionResult<Status> GetByIdStatus(int id)
        {
            var result = UnitOfWork.StatusRepository.GetByID(id);
            if (result== null)
            {
                return BadRequest("The status insert is deleted and you can access it");
            }
            return Ok(result);
        }

        [HttpGet("machineid/{id}", Name = "GetStatusByMachineID")]
        public async Task<ActionResult<List<Status>>> GetStatusByIdMachine(int id)
        {
            //TODO:CHECK 31/03
            var result = await UnitOfWork.StatusRepository.GetStatusByIDMachine(id);
            if (result == null)
            {
                return BadRequest("The machine insert not exists or not have status");
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
            //TODO:CHECK 31/03
            var result = await UnitOfWork.StatusRepository.GetLastStatusByIDMachine(id);
            if (result == null)
            {
                return BadRequest("The machine insert not exists or not have status");
            }
            else
            {

                return Ok(result);
            }

        }
        [HttpGet("StatusName")]
        public async Task<ActionResult<List<string>>> GetStatusName()
        {
            //TODO:CHECK 31/03
            return  await UnitOfWork.StatusRepository.GetNameStatus();
        }
        // POST: api/StatusControllerr
        [HttpPost]
        public ActionResult<Status> PostStatus([FromBody] Status status)
        {
            var statusInsert = UnitOfWork.StatusRepository.Insert(status);
            UnitOfWork.StatusRepository.SaveAll();
            return Ok(statusInsert);
        }

        // PUT: api/StatusControllerr/5
        [HttpPut("{id}")]
        public ActionResult<Status> PutStatus([FromBody] Status status)
        {
            var result = UnitOfWork.StatusRepository.GetByID(status.Id);
            if (result == null)
            {
                return BadRequest("The Status insert not exists or id deleted");
            }
            else
            {
                var statusUpdate = UnitOfWork.StatusRepository.Update(status);
                UnitOfWork.StatusRepository.SaveAll();
                return Ok(statusUpdate);
            }
            
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<Status> DeleteStatus(int id)
        {
            //TODO:CHECK 31/03
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
