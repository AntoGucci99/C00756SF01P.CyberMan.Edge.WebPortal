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
        public ActionResult<Task<IEnumerable<Alert>>> GetAlerts()
        {
            var alertList = UnitOfWork.AlertRepository.GetAll();
            if (alertList == null)
            {
                return BadRequest("There is no alert");
            }
            else
            {
                return Ok(alertList);
            }
            
        }

        // GET: api/Alert/5
        [HttpGet("{id}", Name = "GetByIdAlert")]
        public ActionResult<Alert> GetByIdAlert(int id)
        {

            var result = UnitOfWork.AlertRepository.GetByID(id);
            if (result == null)
            {
                return BadRequest("Alert inserit not eists");
            }
            else if (result.IsDeleted == true)
            {
                return BadRequest("Alert inserit is deleted and you can't access it");
            }
            else
            {
                return Ok(result);
            }
        }
        [HttpGet("machineid/{id}", Name = "GetAlertByMachineID")]
        public async Task<ActionResult<List<Alert>>> GetAlertByIdMachine(int id)
        {
            var result = await UnitOfWork.AlertRepository.GetAlertByIDMachine(id);
            if (result.Count==0)
            {
                return BadRequest("IdMacchina not exists or not have alerts");
            }
            else
            {
                return Ok(result);
            }

        }
        [HttpGet("lastalertbymachineid/{id}", Name = "GetLastAlertByMachineId")]
        public async Task<ActionResult<Task<Alert>>> GetLastAlertByIDMachineAsync(int id)
        {
            var result = await UnitOfWork.AlertRepository.GetLastAlertByIDMachine(id);
            if (result == null)
            {
               return BadRequest("IdMacchina not exists or not have alert");
            }
            else
            {
                return Ok(result);
            }

        }

        // POST: api/Alert
        [HttpPost]
        public ActionResult<Alert> PostAlert([FromBody] Alert alert)
        {
                var alertInsert=UnitOfWork.AlertRepository.Insert(alert);
                UnitOfWork.AlertRepository.SaveAll();
                return Ok(alertInsert);
        }

        // PUT: api/Alert/5
        [HttpPut("{id}")]
        public ActionResult<Alert> PutAlert([FromBody] Alert alert)
        {
             var alertUpdate=UnitOfWork.AlertRepository.Update(alert);
             UnitOfWork.AlertRepository.SaveAll();
             return Ok(alertUpdate);

        }
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<Alert> DeleteAlert(int id)
        {  
            var alertDeleted=UnitOfWork.AlertRepository.Delete(id);
            if (alertDeleted == null)
            {
                return BadRequest("Alert insert not exists");
            }
            else
            {
                UnitOfWork.AlertRepository.SaveAll();
                return Ok(alertDeleted);
            }
        }
    }
}
