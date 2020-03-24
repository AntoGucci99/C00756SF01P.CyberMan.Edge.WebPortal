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
        public Alert GetByIdAlert(int id)
        {
            return UnitOfWork.AlertRepository.GetByID(id);
        }

        // POST: api/Alert
        [HttpPost]
        public void PostAlert([FromBody] Alert alert)
        {
            UnitOfWork.AlertRepository.Insert(alert);
            UnitOfWork.AlertRepository.SaveAll();
        }

        // PUT: api/Alert/5
        [HttpPut("{id}")]
        public void PutAlert(int id, [FromBody] Alert alert)
        {
            if (id == alert.Id)
            {
                UnitOfWork.AlertRepository.Update(alert);
                UnitOfWork.AlertRepository.SaveAll();
            }
            else
            {
                BadRequest();
            }

        }
        // GET: api/Alert/8
        [HttpGet("{idMachine}", Name = "GetByIdAlertByIdMachine")]
        public async Task<List<Alert>> GetAlertByIdMachine(int id)
        {
            return await UnitOfWork.AlertRepository.GetAlertByIDMachine(id);
        }
        [HttpGet("{idMachine2}", Name = "GetByIdAlertByIdMachine")]
        public async Task<Alert> GetLastAlertByIdMachine(int id)
        {
            return await UnitOfWork.AlertRepository.GetLastAlertByIDMachine(id);
        }
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void DeleteAlert(int id)
        {
            UnitOfWork.AlertRepository.Delete(id);
            UnitOfWork.AlertRepository.SaveAll();
        }
    }
}
