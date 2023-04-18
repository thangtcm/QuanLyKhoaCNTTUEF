using QuanLyKhoaCNTTUEF.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace QuanLyKhoaCNTTUEF.Models
{
    public class Event
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? EventID { get; set; }

        public int? PlanID { get; set; }
        [ForeignKey("PlanID")]
        public virtual Plan? Plan { get; set; }

        [DisplayName("Tên sự kiện")]
        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "This field is required.")]
        public string? EventName { get; set; }

        [DisplayName("Ngày bắt đầu")]
        [Required(ErrorMessage = "This field is required.")]
        public DateTime StartTime { get; set; }

        [DisplayName("Ngày kết thúc")]
        [Required(ErrorMessage = "This field is required.")]
        public DateTime EndTime { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [DisplayName("Mô tả")]
        public string? Description { get; set; }

        [DisplayName("Trạng thái")]
        public int TrangThai { get; set; }

        public int XoaTam { get; set; }

        [DisplayName("Người tạo")]
        public string? UserCreate { get; set; }
        [ForeignKey("UserCreate")]
        public virtual ApplicationUser? UserCreated { get; set; }

        [DisplayName("Ngày tạo")]
        public DateTime CreateDate { get; set; }

        [DisplayName("Người cập nhật")]
        public string? UserUpdate { get; set; }
        [ForeignKey("UserUpdate")]
        public virtual ApplicationUser? UserUpdated { get; set; }

        [DisplayName("Ngày cập nhật")]
        public DateTime UpdateDate { get; set; }

        [DisplayName("Người Xóa")]
        public string? UserDelete { get; set; }
        [ForeignKey("UserDelete")]
        public virtual ApplicationUser? UserDeleted { get; set; }

        [DisplayName("Ngày xoá")]
        public DateTime NgayXoa { get; set; }

        
        public virtual ICollection<Group>? Groups { get; set; }
        public virtual ICollection<Tasks>? Tasks { get; set; }
    }
}
