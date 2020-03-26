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
            try
            {
                var result = UnitOfWork.StatusRepository.GetByID(id);
                if (result.IsDeleted == true)
                {
                    return BadRequest("lo status inserito è stato eliminato e non puoi piu vederlo");
                }
                return result;
            }
            catch (Exception)
            {
                return BadRequest("Lo Status inserito non esiste");
            }
         
        }

        [HttpGet("machineid/{id}", Name = "GetStatusByMachineID")]
        //metodo con await e async
        public  ActionResult<Task<List<Status>>> GetStatusByIdMachine(int id)
        {
            var result= UnitOfWork.StatusRepository.GetStatusByIDMachine(id);
            if (result == null)
            {
                return BadRequest("idMacchina inseistente o stati inesistenti in questa macchina");
            }
            else
            {
                return Ok(result);
            }
            
        }
        [HttpGet("laststatudbymachineid/{id}", Name = "GetLastStatusByMachineId")]
        //metodo con await e async
        public  ActionResult<Task<Status>> GetLastStatusByIDMachine(int id)
        {
            var result =  UnitOfWork.StatusRepository.GetLastStatusByIDMachine(id);
            if ( result== null)
            {
                return BadRequest("idMacchina non esiste o non ha stati");
            }
            else
            {
                return Ok(result);
            }

        }
        [HttpGet("StatusName")]
        public async Task<List<string>> GetStatusName()
        {
            return await UnitOfWork.StatusRepository.GetNameStatus();
        }
        // POST: api/StatusControllerr
        [HttpPost]
        public ActionResult PostStatus([FromBody] Status status)
        {
            try
            {
                UnitOfWork.StatusRepository.Insert(status);
                UnitOfWork.StatusRepository.SaveAll();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("impossibile Inserire");
            }
        }

        // PUT: api/StatusControllerr/5
        [HttpPut("{id}")]
        public ActionResult PutStatus(int id, [FromBody] Status status)
        {
            if (id == status.Id)
            {
                try
                {
                    UnitOfWork.StatusRepository.Update(status);
                    UnitOfWork.StatusRepository.SaveAll();
                    return Ok();
                }
                catch (Exception)
                {
                    return BadRequest("impossibile aggiornare");
                }
                
            }
            else
            {
                return BadRequest("non puoi cambiare l'id dello stato");
            }

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult DeleteStatus(int id)
        {
            try
            {
                UnitOfWork.StatusRepository.Delete(id);
                UnitOfWork.StatusRepository.SaveAll();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Impossibile eliminare lo stato,o non esiste o c'è stato un'altro problema");
            }

}
    }

}
