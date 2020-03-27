using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace C00756SF01P.CyberMan.Edge.WebAPI.Data.Entities
{
    public class Alert : EntityBase/*, ITrackingDelete*/
    {
        //TODO: cambiare alertmessage in messgae, typealert in alert, e così per tutte le classi
        [Required]
        public string Type{ get; set; }
        [Required]
        public string Message { get; set; }
        public DateTime InsertDate { get; set; }
        [Required]
        public int MachineId { get; set; }
        public Machine Machine { get; set; }
        //public bool IsDeleted { get; set; }
    }
}
