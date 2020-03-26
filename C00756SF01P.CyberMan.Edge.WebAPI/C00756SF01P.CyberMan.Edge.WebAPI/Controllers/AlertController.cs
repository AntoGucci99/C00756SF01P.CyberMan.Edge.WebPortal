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
            return Ok(alertList);
        }

        // GET: api/Alert/5
        [HttpGet("{id}", Name = "GetByIdAlert")]
        public ActionResult<Alert> GetByIdAlert(int id)
        {
            
            var result = UnitOfWork.AlertRepository.GetByID(id);
            if (result.IsDeleted == true)
            {
               return BadRequest("Alert inserit is deleted and you can't access it");
            }
            return Ok(result);  
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
        // GET: api/Alert/8
        [HttpGet("{idMachine}", Name = "GetByIdAlertByIdMachine")]
        public  ActionResult<Task<List<Alert>>> GetAlertByIdMachine(int id)
        {
            
                var result = UnitOfWork.AlertRepository.GetByID(id);
                if (result.IsDeleted == true)
                {
                    return BadRequest("the machine not exists or not have alert");
                }
                return Ok(result);
            
            
        }
        [HttpGet("{idMachine2}", Name = "GetIdAlertByIdMachine")]
        public ActionResult<Task<Alert>> GetLastAlertByIdMachine(int id)
        {
            var result = UnitOfWork.AlertRepository.GetAlertByIDMachine(id);
            if (result == null)
            {
                return BadRequest("the machine not exists or not have alert");
            }
            else
            {
                return Ok(result);
            }
        }
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<Alert> DeleteAlert(int id)
        {
            
                var alertDeleted=UnitOfWork.AlertRepository.Delete(id);
                UnitOfWork.AlertRepository.SaveAll();
            return Ok(alertDeleted);
            
        }
    }
}
