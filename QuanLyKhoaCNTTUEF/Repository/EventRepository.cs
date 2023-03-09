using Microsoft.EntityFrameworkCore;
using QuanLyKhoaCNTTUEF.Contracts;
using QuanLyKhoaCNTTUEF.Data;
using QuanLyKhoaCNTTUEF.Models;

namespace QuanLyKhoaCNTTUEF.Repository
{
    public class EventRepository : IEventRepository, IDisposable
    {
        private ApplicationDbContext _context;
        public EventRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public IEnumerable<Event> GetEvents()
        {
            return _context.Event.ToList();
        }

        public Event GetEventByID(int eventID)
        {
            return _context.Event.Find(eventID);
        }

        public void Create(Event @event)
        {
            _context?.Event?.Add(@event);
        }

        public void Delete(int eventID)
        {
            Event? @event = _context?.Event?.Find(eventID);
            _context?.Event?.Remove(@event);
        }

        public void Update(Event @event)
        {
            _context.Entry(@event).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
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
