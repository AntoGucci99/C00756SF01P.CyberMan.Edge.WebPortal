using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C00756SF01P.CyberMan.Edge.WebAPI.Data.Entities
{
    public interface ITrackingDelete
    {
        bool IsDeleted { get; set; }
    }

    public abstract class EntityBase: ITrackingDelete
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
