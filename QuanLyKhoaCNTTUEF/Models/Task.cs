using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyKhoaCNTTUEF.Models
{
    public class Task
    {
        [Key]
        [Column(TypeName = "varchar(20)")]
        [Display(Name ="ID Sự kiện")]
        public string IDSuKien { get; set; }
        [Column(TypeName = "varchar(50)")]
        [Display(Name = "ID Task")]
        public string IDTask { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Display(Name = "Tên Task")]
        public string? TenTask { get; set; }
        [Column(TypeName = "nvarchar(150)")]
        [Display(Name = "Mô tả")]
        public string? MoTa { get; set; }
        [Column(TypeName = "nvarchar(150)")]
        [Display(Name = "Chi tiết")]
        public string? ChiTiet { get; set; }
        [Display(Name = "Ngày bắt đầu")]
        public DateTime NgayBD { get; set; }
        [Display(Name = "Ngày kết thúc")]
        public DateTime NgayKT { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Display(Name = "Trạng thái")]
        public int TrangThai { get; set; }
        [Column(TypeName = "nvarchar(150)")]
        [Display(Name = "Đánh giá")]
        public string? DanhGia { get; set; }
    }
}
