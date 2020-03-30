﻿using System;
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
            //TODO:CHECK 31/03, PLURALE DI STATUS E' SEMPRE STATUS
            var status = UnitOfWork.StatusRepository.GetAll();
            return Ok(status);
        }

        // GET: api/StatusControllerr/5
        [HttpGet("statusid/{id}", Name = "GetStatusById")]
        public ActionResult<Status> GetByIdStatus(int id)
        {
            var result = UnitOfWork.StatusRepository.GetByID(id);
            if (result.IsDeleted == true)
            {
                return BadRequest("The status insert is deleted and you can access it");
            }
            return Ok(result);
        }

        [HttpGet("machineid/{id}", Name = "GetStatusByMachineID")]
        //metodo con await e async
        public async Task<ActionResult<List<Status>>> GetStatusByIdMachine(int id)
        {
            //TODO:CHECK 31/03
            var result = await UnitOfWork.StatusRepository.GetStatusByIDMachine(id);
            return Ok(result);
        }
        [HttpGet("laststatudbymachineid/{id}", Name = "GetLastStatusByMachineId")]
        //metodo con await e async
        public async Task<ActionResult<Task<Status>>> GetLastStatusByIDMachineAsync(int id)
        {
            //TODO:CHECK 31/03
            var result = await UnitOfWork.StatusRepository.GetLastStatusByIDMachine(id);
            return Ok(result);
        }
        [HttpGet("StatusName")]
        public async Task<ActionResult<List<string>>> GetStatusName()
        {
            //TODO:CHECK 31/03
            var statusName = await UnitOfWork.StatusRepository.GetNameStatus();
            return Ok(statusName);
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
            var statusUpdate = UnitOfWork.StatusRepository.Update(status);
            UnitOfWork.StatusRepository.SaveAll();
            return Ok(statusUpdate);
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
