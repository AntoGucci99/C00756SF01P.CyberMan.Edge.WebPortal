using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C00756SF01P.CyberMan.Edge.WebAPI.Data.Entities
{
    public class Alert : EntityBase
    {
        public string TypeAllert { get; set; }
        public string AlertMessage { get; set; }
        public DateTime InsertDate { get; set; }
        public int MachineId { get; set; }
        public Machine Machine { get; set; }
        

    }
}
