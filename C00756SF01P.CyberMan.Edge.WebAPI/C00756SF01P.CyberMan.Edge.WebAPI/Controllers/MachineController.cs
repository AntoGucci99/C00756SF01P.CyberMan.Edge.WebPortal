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
        public Machine GetMachineById(int id)
        {
            return UnitOfWork.MachineRepository.GetByID(id);
        }

        // POST: api/Machine
        [HttpPost]
        public void PostMachine([FromBody] Machine machine)
        {
            UnitOfWork.MachineRepository.Insert(machine);
            UnitOfWork.MachineRepository.SaveAll();
        }

        // PUT: api/Machine/5
        [HttpPut("{id}")]
        public void PutMachine(int id, [FromBody] Machine machine)
        {
            if (id == machine.Id)
            {
                UnitOfWork.MachineRepository.Update(machine);
                UnitOfWork.MachineRepository.SaveAll();
            }
            else
            {
                BadRequest();
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void DeleteMachine(int id)
        {
            UnitOfWork.MachineRepository.Delete(id);
            UnitOfWork.MachineRepository.SaveAll();
        }

    }
}
