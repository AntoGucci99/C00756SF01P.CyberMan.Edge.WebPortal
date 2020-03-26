using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace C00756SF01P.CyberMan.Edge.WebAPI.Data.Entities
{
    public class Alert : EntityBase
    {
        [Required]
        public string TypeAllert { get; set; }
        [Required]
        public string AlertMessage { get; set; }
        public DateTime InsertDate { get; set; }
        [Required]
        public int MachineId { get; set; }
        public Machine Machine { get; set; }
        

    }
}
