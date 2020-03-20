using C00756SF01P.CyberMan.Edge.WebAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C00756SF01P.CyberMan.Edge.WebAPI
{
    public class Status : EntityBase
    {
        public string StatusName { get; set; }
        public string StatusCurrent { get; set; }
        public int MachineId { get; set; }
        public Machine Machine { get; set; }
        //public int AlertId { get; set; }
        //public int MachineId {get; set;}

    }
}
