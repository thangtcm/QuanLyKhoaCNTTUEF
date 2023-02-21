using QuanLyKhoaCNTTUEF.Data;

namespace QuanLyKhoaCNTTUEF.Models.ChatModel
{
    public class Message
    {
        public int? Id { get; set; }
        public ApplicationUser? Sender { get; set; }
        public string? Content { get; set; }
        public DateTime? SentAt { get; set; }
    }
}
