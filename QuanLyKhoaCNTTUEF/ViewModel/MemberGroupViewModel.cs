using QuanLyKhoaCNTTUEF.Data;
using QuanLyKhoaCNTTUEF.Models;

namespace QuanLyKhoaCNTTUEF.ViewModel
{
    public class MemberGroupViewModel
    {
        public Group? Group { get; set; }
        public List<ApplicationUser>? Members { get; set; }
        public List<string>? SelectedMemberIDs { get; set; }
    }
}
