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
    public class MachineController : ControllerBase
    {
        public UnitOfWork UnitOfWork { get; set; }
        public MachineController(UnitOfWork unit)
        {
            this.UnitOfWork = unit;
        }
        // GET: api/Machine
        [HttpGet]
        public ActionResult<IEnumerable<Machine>> GetMachine()
        {
            return Ok(UnitOfWork.MachineRepository.GetAll());
        }

        // GET: api/Machine/5
        [HttpGet("{id}", Name = "GetMachineById")]
        public ActionResult<Machine> GetMachineById(int id)
        {
            var result = UnitOfWork.MachineRepository.GetByID(id);
            if (result.IsDeleted)
            {
                //TODO:COMMENTO IN INGLESE
                return BadRequest("La macchina inserita è stata eliminata e non puoi piu vederla");
            }
            return result;
        }

        // POST: api/Machine
        [HttpPost]
        public ActionResult PostMachine([FromBody] Machine machine)
        {

            var insertMachine=UnitOfWork.MachineRepository.Insert(machine);
            UnitOfWork.MachineRepository.SaveAll();
            //TODO: RITORNARE L'OGGETTO MACHINE CHE è APPENA STATO INSERITO
            return Ok(insertMachine);


        }
        // PUT: api/Machine/5
        [HttpPut("{id}")]
        public ActionResult PutMachine([FromBody] Machine machine)
        {
            //TODO: TORNARE LA MACCHINE AGGIORNATA
            var machineUpdate=UnitOfWork.MachineRepository.Update(machine);
            UnitOfWork.MachineRepository.SaveAll();
            return Ok(machineUpdate);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult DeleteMachine(int id)
        {

            var machineDeleted=UnitOfWork.MachineRepository.Delete(id);
            UnitOfWork.MachineRepository.SaveAll();
            return Ok(machineDeleted);
        }

    }
}
