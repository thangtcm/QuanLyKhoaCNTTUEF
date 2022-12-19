using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyKhoaCNTTUEF.Models
{
    public class NguoiDung
    {
        [Key]
        public int MSSV { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [EmailAddress(ErrorMessage = "Vui long nhap dung dinh dang!")]
        public string Email { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string HoVaTen { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string ChucVu { get; set; }
    }
}
