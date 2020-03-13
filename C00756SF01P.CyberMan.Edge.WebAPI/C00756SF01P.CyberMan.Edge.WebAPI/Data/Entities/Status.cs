using C00756SF01P.CyberMan.Edge.WebAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C00756SF01P.CyberMan.Edge.WebAPI
{
    public class Status : EntityBase
    {
        public string NameStatus { get; set; }
        public string StatusCurrent { get; set; }

    }
}
