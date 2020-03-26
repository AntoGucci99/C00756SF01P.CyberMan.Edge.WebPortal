using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using C00756SF01P.CyberMan.Edge.WebAPI.Data.Entities;
using C00756SF01P.CyberMan.Edge.WebAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace C00756SF01P.CyberMan.Edge.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlertController : ControllerBase
    {
        public UnitOfWork UnitOfWork { get; set; }
        public AlertController(UnitOfWork unit)
        {
            this.UnitOfWork = unit;
        }
        // GET: api/Alert
        [HttpGet]
        public IEnumerable<Alert> GetAlerts()
        {
            return UnitOfWork.AlertRepository.GetAll();
        }

        // GET: api/Alert/5
        [HttpGet("{id}", Name = "GetByIdAlert")]
        public ActionResult<Alert> GetByIdAlert(int id)
        {
            try
            {
                var result = UnitOfWork.AlertRepository.GetByID(id);
                if (result.IsDeleted == true)
                {
                    return BadRequest("Alesrt inserito è stato eliminato e non puoi piu vederlo");
                }
                return result;
            }
            catch (Exception)
            {
                return BadRequest("Alert inserito non esiste");
            }
            
        }

        // POST: api/Alert
        [HttpPost]
        public ActionResult PostAlert([FromBody] Alert alert)
        {
            try
            {
                UnitOfWork.AlertRepository.Insert(alert);
                UnitOfWork.AlertRepository.SaveAll();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("impossibile Inserire");
            }
        }

        // PUT: api/Alert/5
        [HttpPut("{id}")]
        public ActionResult PutAlert(int id, [FromBody] Alert alert)
        {
            if (id == alert.Id)
            {
                try
                {
                    UnitOfWork.AlertRepository.Update(alert);
                    UnitOfWork.AlertRepository.SaveAll();
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
        // GET: api/Alert/8
        [HttpGet("{idMachine}", Name = "GetByIdAlertByIdMachine")]
        public  ActionResult<Task<List<Alert>>> GetAlertByIdMachine(int id)
        {
            try
            {
                var result = UnitOfWork.AlertRepository.GetByID(id);
                if (result.IsDeleted == true)
                {
                    return BadRequest("Alert inserito è stato eliminato e non puoi piu vederlo");
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest("Alert inserito non esiste");
            }
        }
        [HttpGet("{idMachine2}", Name = "GetIdAlertByIdMachine")]
        public ActionResult<Task<Alert>> GetLastAlertByIdMachine(int id)
        {
            var result = UnitOfWork.AlertRepository.GetAlertByIDMachine(id);
            if (result == null)
            {
                return BadRequest("idMacchina inseistente o alert inesistenti in questa macchina");
            }
            else
            {
                return Ok(result);
            }
        }
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult DeleteAlert(int id)
        {
            try
            {
                UnitOfWork.AlertRepository.Delete(id);
                UnitOfWork.AlertRepository.SaveAll();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Impossibile eliminare,non esiste o altro problema");
            }
            
        }
    }
}
