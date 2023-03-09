using QuanLyKhoaCNTTUEF.Models;

namespace QuanLyKhoaCNTTUEF.ViewModel
{
    public class EventViewModel
    {
        public string? EventName { get; set; }
        public IEnumerable<GroupViewModel>? Groups { get; set; }
    }
}
