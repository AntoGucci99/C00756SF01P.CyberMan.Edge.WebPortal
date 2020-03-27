using C00756SF01P.CyberMan.Edge.WebAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace C00756SF01P.CyberMan.Edge.WebAPI
{
    public class Status : EntityBase/*, ITrackingDelete*/
    {
        [Required]
        public string StatusName { get; set; }
        [Required]
        public string StatusCurrent { get; set; }
        public int MachineId { get; set; }
        public Machine Machine { get; set; }
        //public bool IsDeleted { get; set; }
        //public int AlertId { get; set; }
        //public int MachineId {get; set;}

    }
}
