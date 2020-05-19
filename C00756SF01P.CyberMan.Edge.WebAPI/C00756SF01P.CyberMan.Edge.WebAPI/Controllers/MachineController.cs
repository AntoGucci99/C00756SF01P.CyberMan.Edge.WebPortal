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
            var machineList = UnitOfWork.MachineRepository.GetAll();
            return Ok(machineList);
        }

        // GET: api/Machine/5
        [HttpGet("{id}", Name = "GetMachineById")]
        public ActionResult<Machine> GetMchineById(int id)
        {
            //TODO:CHECK 31/03
            var result = UnitOfWork.MachineRepository.GetByID(id);
            if (result == null || result.IsDeleted == true  )
            {
                return BadRequest("The Machine Insert is deleted and you can't access it");
            }
            return Ok(result);
        }

        // POST: api/Machine
        [HttpPost]
        public ActionResult<Machine> PostMachine([FromBody] Machine machine)
        {
            var insertMachine = UnitOfWork.MachineRepository.Insert(machine);
            UnitOfWork.MachineRepository.SaveAll();
            return Ok(insertMachine);
        }
        // PUT: api/Machine/5
        [HttpPut("{id}")]
        public ActionResult<Machine> PutMachine([FromBody] Machine machine)
        {
            var result = UnitOfWork.MachineRepository.GetByID(machine.Id);
            if (result == null)
            {
                return BadRequest("The Machine Insert is deleted or not exists and you can't access it");
            }
            else
            {
                var machineUpdate = UnitOfWork.MachineRepository.Update(machine);
                UnitOfWork.MachineRepository.SaveAll();
                return Ok(machineUpdate);
            }
            
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<Machine> DeleteMachine(int id)
        {
            //TODO:CHECK 31/03
            var machineDeleted = UnitOfWork.MachineRepository.Delete(id);
            if (machineDeleted == null)
            {
                return BadRequest("The machine insert not exists");
            }
            else
            {
                UnitOfWork.MachineRepository.SaveAll();
                return Ok(machineDeleted);
            }
        }

    }
}
