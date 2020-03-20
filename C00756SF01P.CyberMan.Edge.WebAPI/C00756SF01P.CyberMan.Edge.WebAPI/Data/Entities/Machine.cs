using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C00756SF01P.CyberMan.Edge.WebAPI.Data.Entities
{
    public class Machine : EntityBase
    {
        public string MachineName { get; set; }
        public int LineId { get; set; }
        public string UserInsert { get; set; }
        public DateTime DateInsert { get; set; }
        public ICollection<Alert> Alerts { get; set; }
        public ICollection<Status> Status { get; set; }


    }
}
