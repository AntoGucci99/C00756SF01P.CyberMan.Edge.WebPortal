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
        public IEnumerable<Machine> GetMachine()
        {
            return UnitOfWork.MachineRepository.GetAll();
        }

        // GET: api/Machine/5
        [HttpGet("{id}", Name = "GetMachineById")]
        public ActionResult<Machine> GetMachineById(int id)
        {
            try
            {
                var result = UnitOfWork.MachineRepository.GetByID(id);
                if (result.IsDeleted == true)
                {
                    return BadRequest("La macchina inserita è stata eliminata e non puoi piu vederla");
                }
                return result;
            }
            catch (Exception)
            {
                return BadRequest("La macchina inserita non esiste");
            }
             
        }

        // POST: api/Machine
        [HttpPost]
        public ActionResult PostMachine([FromBody] Machine machine)
        {
            try
            {
                UnitOfWork.MachineRepository.Insert(machine);
                UnitOfWork.MachineRepository.SaveAll();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("impossibile fare insert");
            }

        }
        // PUT: api/Machine/5
        [HttpPut("{id}")]
        public ActionResult PutMachine(int id, [FromBody] Machine machine)
        {
            if (id == machine.Id)
            {
                try
                {
                    UnitOfWork.MachineRepository.Update(machine);
                    UnitOfWork.MachineRepository.SaveAll();
                    return Ok();
                }
                catch (Exception)
                {
                    return BadRequest("impossibile aggiornare");
                }               
            }
            else
            {
                BadRequest("Non puoi cambiare l'id");
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult DeleteMachine(int id)
        {
            try
            {
                UnitOfWork.MachineRepository.Delete(id);
                UnitOfWork.MachineRepository.SaveAll();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Impossibile eliminare,non esiste o altro problema");
            }
            
        }

    }
}
