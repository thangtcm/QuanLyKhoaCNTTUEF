using NuGet.Protocol.Core.Types;
using QuanLyKhoaCNTTUEF.Data;
using QuanLyKhoaCNTTUEF.Models;

namespace QuanLyKhoaCNTTUEF.Repository
{
    public class UnitOfWork : IDisposable
    {
        private ApplicationDbContext context;
        private GenericRepository<Event> eventRepository;
        private GenericRepository<Plan> planRepository;

        public UnitOfWork(ApplicationDbContext context, GenericRepository<Event> eventRepository, GenericRepository<Plan> planRepository)
        {
            this.context = context;
            this.eventRepository = eventRepository;
            this.planRepository = planRepository;
        }

        public GenericRepository<Event> EventRepository
        {
            get
            {

                if (this.eventRepository == null)
                {
                    this.eventRepository = new GenericRepository<Event>(context);
                }
                return eventRepository;
            }
        }

        public GenericRepository<Plan> PlanRepository
        {
            get
            {

                if (this.planRepository == null)
                {
                    this.planRepository = new GenericRepository<Plan>(context);
                }
                return planRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
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
