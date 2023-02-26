using QuanLyKhoaCNTTUEF.Models.Files;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyKhoaCNTTUEF.Models
{
    public class Plan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDKeHoach { get; set; }

        [DisplayName("Tên Kế Hoạch")]
        [Column(TypeName = "nvarchar(50)")]
        public string? TenKeHoach { get; set; }

        [DisplayName("Ngày Trình")]
        public DateTime NgayTrinh { get; set; }

        [DisplayName("Ngày Duyệt")]
        public DateTime NgayDuyet { get; set; }

        [DisplayName("Người Trình")]
        [Column(TypeName = "nvarchar(50)")]
        public string? NguoiTrinh { get; set; }

        [DisplayName("Người Duyệt")]
        [Column(TypeName = "nvarchar(50)")]
        public string? NguoiDuyet { get; set; }

        public List<PdfFile>? PdfFiles { get; set; }

        public List<Event>? Events { get; set; }
    }
}
