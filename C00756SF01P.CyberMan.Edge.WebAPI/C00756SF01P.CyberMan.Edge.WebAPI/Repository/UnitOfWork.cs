using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C00756SF01P.CyberMan.Edge.WebAPI.Repository
{
    public class UnitOfWork : IDisposable
    {
        private AppContext Context;
        private StatusRepository statusRepository;
        private MachineRepository machineRepository;
        private AlertRepository alertRepository;

        public UnitOfWork(AppContext context)
        {
            this.Context = context;
        }
        public StatusRepository StatusRepository
        {
            get
            {
                if (this.statusRepository == null)
                {
                    this.statusRepository = new StatusRepository(this.Context);
                }
                return statusRepository;
            }
        }
        public MachineRepository MachineRepository
        {
            get
            {
                if (this.machineRepository == null)
                {
                    this.machineRepository = new MachineRepository(this.Context);
                }
                return machineRepository;
            }
        }
        public AlertRepository AlertRepository
        {
            get
            {
                if (this.alertRepository == null)
                {
                    this.alertRepository = new AlertRepository(this.Context);
                }
                return alertRepository;
            }
        }
        public void Save()
        {
            Context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
