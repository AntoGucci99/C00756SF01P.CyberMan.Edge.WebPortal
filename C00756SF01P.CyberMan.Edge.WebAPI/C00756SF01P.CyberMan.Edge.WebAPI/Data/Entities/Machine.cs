using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace C00756SF01P.CyberMan.Edge.WebAPI.Data.Entities
{
    public class Machine : EntityBase/*, ITrackingDelete*/
    {
        [Required]
        public string MachineName { get; set; }
        [Required]
        public int LineId { get; set; }
        [Required]
        public string UserInsert { get; set; }
        public DateTime DateInsert { get; set; }
        public ICollection<Alert> Alerts { get; set; }
        public ICollection<Status> Status { get; set; }
        //public bool IsDeleted { get; set; }
    }
}
