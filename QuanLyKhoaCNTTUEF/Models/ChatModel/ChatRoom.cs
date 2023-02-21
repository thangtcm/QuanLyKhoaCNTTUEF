using QuanLyKhoaCNTTUEF.Data;

namespace QuanLyKhoaCNTTUEF.Models.ChatModel
{
    public class ChatRoom
    {
        public int? Id { get; set; }
        public ApplicationUser? User1 { get; set; }
        public ApplicationUser? User2 { get; set; }
        public ICollection<Message>? Messages { get; set; }
    }
}
