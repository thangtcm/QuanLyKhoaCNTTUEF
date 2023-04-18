using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyKhoaCNTTUEF.Models
{
    public class Tasks
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? TaskID { get; set; }
        public int? EventID { get; set; }
        [ForeignKey("EventID")]
        public virtual Event? Event { get; set; }

        [DisplayName("Tên Nhiệm Vụ")]
        [Column(TypeName = "varchar(50)")]
        public string? TaskName { get; set; }

        [DisplayName("Mô Tả")]
        public string? Description { get; set; }

        [DisplayName("Ngày Bắt Đầu")]
        public DateTime StartTime { get; set; }

        [DisplayName("Ngày Kết Thúc")]
        public DateTime EndTime { get; set; }

        [DisplayName("Trạng Thái")]
        public bool Status { get; set; }
        public int? GroupID { get; set; }
        [ForeignKey("GroupID")]
        public virtual Group? Group { get; set; }
    }
}
