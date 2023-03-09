using QuanLyKhoaCNTTUEF.Models;

namespace QuanLyKhoaCNTTUEF.Contracts
{
    public interface IEventRepository : IDisposable
    {
        IEnumerable<Event> GetEvents();
        Event GetEventByID(int eventID);
        void Create(Event @event);
        void Delete(int eventID);
        void Update(Event @event);
        void Save();
    }
}
