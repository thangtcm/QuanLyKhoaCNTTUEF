using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyKhoaCNTTUEF.Models
{
    public class NguoiDung
    {
        [Key]
        [DisplayName("Mã Số Sinh Viên")]
        public int MSSV { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [DisplayName("Email")]
        [EmailAddress(ErrorMessage = "Vui long nhap dung dinh dang!")]
        public string Email { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [DisplayName("Họ Và Tên")]
        public string HoVaTen { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [DisplayName("Chức Vụ")]
        public string ChucVu { get; set; }
    }
}
